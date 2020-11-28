using FluentAssertions;
using System;
using Xunit;

namespace SvSoft.DomainPrimitives
{
    public class KindOfTPrimitiveTests
    {
        [Fact]
        public void Can_be_used_as_underlying_type()
        {
            FirstName firstName = new FirstName("John");

            string firstNameStr = firstName;

            firstNameStr.Should().Be("John");
        }

        [Fact]
        public void Can_not_be_used_as_different_type_with_same_underlying_type()
        {
            FirstName firstName = new FirstName("John");

            firstName.Should().NotBeAssignableTo<LastName>();
        }

        [Fact]
        public void Ctor_When_underlying_value_is_null_Then_throws_ArgumentNullException()
        {
            Action act = () => new FirstName(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Equals_When_types_are_same_and_underlying_value_is_same_Then_returns_true()
        {
            FirstName john1 = new FirstName("John");
            FirstName john2 = new FirstName("John");

            var isEqual = john1.Equals(john2);

            isEqual.Should().BeTrue();
        }

        [Fact]
        public void Equals_When_types_are_same_and_underlying_values_are_different_Then_returns_false()
        {
            FirstName john = new FirstName("John");
            FirstName jane = new FirstName("Jane");

            var isEqual = john.Equals(jane);

            isEqual.Should().BeFalse();
        }

        [Fact]
        public void Equals_When_types_are_different_and_underlying_value_is_same_Then_returns_false()
        {
            FirstName john1 = new FirstName("John");
            LastName john2 = new LastName("John");

            var isEqual = john1.Equals(john2);

            isEqual.Should().BeFalse();
        }

        [Fact]
        public void GetHashCode_When_underlying_value_is_different_Then_is_likely_different()
        {
            var john = new FirstName("John");
            var jane = new FirstName("Jane");

            var johnHash = john.GetHashCode();
            var janeHash = jane.GetHashCode();

            johnHash.Should().NotBe(janeHash);
        }

        [Fact]
        public void GetHashCode_When_type_and_underlying_value_is_same_Then_is_same()
        {
            var john1 = new FirstName("John");
            var john2 = new FirstName("John");

            var john1Hash = john1.GetHashCode();
            var john2Hash = john2.GetHashCode();

            john1Hash.Should().Be(john2Hash);
        }

        [Fact]
        public void GetHashCode_When_types_are_different_And_underlying_value_is_same_Then_is_likely_different()
        {
            FirstName john1 = new FirstName("John");
            LastName john2 = new LastName("John");

            var john1Hash = john1.GetHashCode();
            var john2Hash = john2.GetHashCode();

            john1Hash.Should().NotBe(john2Hash);
        }

        [Fact]
        public void ToString_equivalent_to_string_representation_of_underlying_value()
        {
            new FirstName("John").ToString().Should().Be("John");
        }

        [Fact]
        public void InterpolatedString_is_equivalent_to_underlying_value_string_representation()
        {
            var firstName = new FirstName("John");

            $"{firstName}".Should().Be("John");
        }

        [Fact]
        public void When_used_as_string_is_equivalent_to_underlying_value()
        {
            FirstName firstName = new FirstName("John");
            string firstNameStr = firstName;

            firstNameStr.Should().Be("John");
        }

        [Fact]
        public void OperatorEquals_When_types_are_same_and_underlying_value_is_same_Then_returns_true()
        {
            FirstName john1 = new FirstName("John");
            FirstName john2 = new FirstName("John");

            var isEqual = john1 == john2;
            var isEqual2 = john2 == john1;

            isEqual.Should().BeTrue();
            isEqual2.Should().BeTrue();
        }

        [Fact]
        public void OperatorEquals_When_types_are_same_and_underlying_values_are_different_Then_returns_false()
        {
            FirstName john = new FirstName("John");
            FirstName jane = new FirstName("Jane");

            var isEqual = john == jane;
            var isEqual2 = jane == john;

            isEqual.Should().BeFalse();
            isEqual2.Should().BeFalse();
        }

        [Fact]
        public void OperatorEquals_When_types_are_different_and_underlying_value_is_same_Then_returns_false()
        {
            FirstName john1 = new FirstName("John");
            LastName john2 = new LastName("John");

            var isEqual = john1 == john2;
            var isEqual2 = john2 == john1;

            isEqual.Should().BeFalse();
            isEqual2.Should().BeFalse();
        }

        [Fact]
        public void OperatorNotEquals_When_types_are_same_and_underlying_value_is_same_Then_returns_false()
        {
            FirstName john1 = new FirstName("John");
            FirstName john2 = new FirstName("John");

            var isEqual = john1 != john2;
            var isEqual2 = john2 != john1;

            isEqual.Should().BeFalse();
            isEqual2.Should().BeFalse();
        }

        [Fact]
        public void OperatorNotEquals_When_types_are_same_and_underlying_values_are_different_Then_returns_true()
        {
            FirstName john = new FirstName("John");
            FirstName jane = new FirstName("Jane");

            var isEqual = john != jane;
            var isEqual2 = jane != john;

            isEqual.Should().BeTrue();
            isEqual2.Should().BeTrue();
        }

        [Fact]
        public void OperatorNotEquals_When_types_are_different_and_underlying_value_is_same_Then_returns_true()
        {
            FirstName john1 = new FirstName("John");
            LastName john2 = new LastName("John");

            var isEqual = john1 != john2;
            var isEqual2 = john2 != john1;

            isEqual.Should().BeTrue();
            isEqual2.Should().BeTrue();
        }


        private class FirstName : KindOf<string, FirstName>
        {
            public FirstName(string value)
                : base(value)
            {
            }
        }

        private class LastName : KindOf<string, LastName>
        {
            public LastName(string value)
                : base(value)
            {
            }
        }
    }
}
