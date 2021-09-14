using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Exceptions.Base;
using Infrastructure.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API.Middlewares
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // Can not be abstract since it's registered via DI
    /// <summary>
    /// Global exception middleware runs in http pipeline.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        /// <summary>
        /// Creates a new <see cref="ExceptionMiddleware"/>.
        /// </summary>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        /// <summary>
        /// Delegate runs in http pipeline.
        /// </summary>
        /// <param name="context">HttpContext carrying the request.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles the exception object, creates the ErrorResponseModel and returns json in response stream.
        /// </summary>
        /// <param name="context">HttpContext carrying the request.</param>
        /// <param name="ex">Exception to be handled.</param>
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new ErrorResponseModel();
            response.AddParam("path", context.Request.GetDisplayUrl());
            response.AddParam("trace-identifier", context.TraceIdentifier);

            if (_environment.IsDevelopment())
            {
                response.AddError("_message", ex.Message);
                response.AddError("_stack-trace", ex.StackTrace);
                response.AddError("_inner-exception", ex.InnerException?.ToString());
            }

            var httpStatusCode = HttpStatusCode.InternalServerError;
            var logLevel = LogLevel.Error;

            response.Message = "The server encountered an internal error or misconfiguration and was unable to complete your request.";

            if (ex is ExceptionBase exceptionBase)
            {
                response.Message = exceptionBase.Message;

                switch (ex)
                {
                    case BadRequestException badRequestException:
                        httpStatusCode = HttpStatusCode.BadRequest;
                        logLevel = LogLevel.Debug;
                        break;

                    case ConflictException conflictException:
                        httpStatusCode = HttpStatusCode.Conflict;
                        logLevel = LogLevel.Debug;
                        break;

                    case UnauthorizedException unauthorizedException:
                        httpStatusCode = HttpStatusCode.Unauthorized;
                        logLevel = LogLevel.Information;
                        break;

                    case NotFoundException notFoundException:
                        httpStatusCode = HttpStatusCode.NotFound;
                        logLevel = LogLevel.Debug;
                        response.AddError("Resource can not be found.");
                        break;

                    case ValidationException validationException:
                    {
                        httpStatusCode = HttpStatusCode.UnprocessableEntity;
                        logLevel = LogLevel.Debug;
                        if (validationException.Errors != null)
                            foreach (var error in validationException.Errors)
                                response.AddError(error.Key, string.Join(" ", error.Value));

                        break;
                    }
                }
            }

            _logger.Log(logLevel, ex, "CorrelationId: {CorrelationId} TraceIdentifier: {TraceIdentifier} Path: {Path}", response.CorrelationId, context.TraceIdentifier, context.Request.GetDisplayUrl());

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
        }
    }
}