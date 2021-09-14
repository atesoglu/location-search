using FluentValidation;

namespace Application.Flows.Locations.Queries
{
    /// <summary>
    /// Object validator for RequestPersonByIdCommand
    /// </summary>
    public class FilterLocationsValidator : AbstractValidator<FilterLocationsCommand>
    {
        /// <summary>
        /// Creates a new instance Of RequestPersonByIdValidator
        /// </summary>
        public FilterLocationsValidator()
        {
            RuleFor(t => t.Latitude)
                .GreaterThanOrEqualTo(-90).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.")
                .LessThanOrEqualTo(90).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.");
            RuleFor(t => t.Longitude)
                .GreaterThanOrEqualTo(-180).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.")
                .LessThanOrEqualTo(180).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.");
            RuleFor(t => t.Distance)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .LessThan(40000).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.");
            RuleFor(t => t.Limit)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .LessThan(1000).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.");
        }
    }
}