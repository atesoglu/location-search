using System.Collections.Generic;
using System.Linq;
using Application.Exceptions;
using Application.Exceptions.Base;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace Application.UnitTests.Exceptions
{
    public class ValidationExceptionTests
    {
        [Fact]
        public void ExtendsFromExceptionBase()
        {
            var actual = new ValidationException();
            actual.Should().BeAssignableTo<ExceptionBase>();
        }

        [Fact]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidationException().Errors;
            actual.Should().BeEquivalentTo(null);
        }

        [Fact]
        public void DefaultConstructorCreatesEmptyParams()
        {
            var actual = new ValidationException().Params;
            actual.Should().BeEmpty();
        }

        [Fact]
        public void SingleParamInsertCreatesSingleElementParamArray()
        {
            var actual = new ValidationException();
            var param = new KeyValuePair<string, string>("key", "value");
            actual.Params.Add(param);

            actual.Params.Count.Should().Be(1);
        }

        [Fact]
        public void SingleParamAdditionCreatesSingleElementParamArray()
        {
            var actual = new ValidationException();
            var param = new KeyValuePair<string, string>("key", "value");
            actual.AddParam(param.Key, param.Value);

            actual.Params.Count.Should().Be(1);
        }

        [Fact]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Age", "must be over 18"),
            };

            var actual = new ValidationException(failures).Errors;
            actual.First().Key.Should().BeEquivalentTo("Age");
            actual.First().Value.Should().BeEquivalentTo("must be over 18");
        }

        [Fact]
        public void MultipleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Age", "must be 18 or older"),
                new ValidationFailure("Age", "must be 25 or younger"),
                new ValidationFailure("Password", "must contain at least 8 characters"),
                new ValidationFailure("Password", "must contain a digit"),
                new ValidationFailure("Password", "must contain upper case letter"),
                new ValidationFailure("Password", "must contain lower case letter"),
            };

            var actual = new ValidationException(failures).Errors;
            actual.Select(s => s.Key).Should().BeEquivalentTo("Password", "Age");
            actual.First(w => w.Key == "Age").Value.Should().BeEquivalentTo("must be 25 or younger", "must be 18 or older");
            actual.First(w => w.Key == "Password").Value.Should().BeEquivalentTo("must contain lower case letter", "must contain upper case letter", "must contain at least 8 characters", "must contain a digit");
        }
    }
}