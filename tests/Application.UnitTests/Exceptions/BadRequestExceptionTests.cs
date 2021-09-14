using System;
using Application.Exceptions;
using Application.Exceptions.Base;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.Exceptions
{
    public class BadRequestExceptionTests
    {
        [Fact]
        public void ExtendsFromExceptionBase()
        {
            var actual = new BadRequestException();
            actual.Should().BeAssignableTo<ExceptionBase>();
        }

        [Fact]
        public void MessageMustMatch()
        {
            var faker = new Faker();
            var sentence = faker.Lorem.Sentence();

            var actual = new BadRequestException(sentence);
            actual.Message.Should().Be(sentence);
        }

        [Fact]
        public void InnerExceptionMustMatch()
        {
            var actual = new BadRequestException(string.Empty, new ArgumentException("must-match"));
            actual.InnerException.Should().BeOfType<ArgumentException>();
        }
    }
}