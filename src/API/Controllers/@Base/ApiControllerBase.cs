using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers.Base
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ILogger<ApiControllerBase> Logger;

        protected ApiControllerBase(ILogger<ApiControllerBase> logger)
        {
            Logger = logger;
        }
    }
}