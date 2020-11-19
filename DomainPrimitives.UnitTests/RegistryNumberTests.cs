using FluentAssertions;
using SvSoft.DomainPrimitives.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SvSoft.DomainPrimitives
{
    public class RegistryNumberTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("12345678")]
        [InlineData("1234567890")]
        [InlineData("1234567-8")]
        public void Ctor_When_value_is_invalid_Then_throws_ArgumentException(string value)
        {
            Action act = () => new RegistryNumber(value);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("ABCDEFGHI")]
        [InlineData("1B3D5F7H9")]
        public void Ctor_When_value_is_valid_Then_does_not_throw(string value)
        {
            Action act = () => new RegistryNumber(value);

            act.Should().NotThrow();
        }
    }
}
