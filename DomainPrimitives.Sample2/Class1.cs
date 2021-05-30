using SvSoft.DomainPrimitives;
using System;

namespace DomainPrimitives.Sample2
{
    public sealed class FirstName : KindOf<string>
    {
        public static Result<FirstName> Create(string value)
        {
            if (value.Equals("Homer", StringComparison.CurrentCultureIgnoreCase))
            {
                return "no Homers allowed";
            }

            return new FirstName(value);
        }

        FirstName(string value) : base(value) { }
    }

    public sealed class LastName : KindOf<string>
    {
        public static Result<LastName> Create(string value) => new LastName(value);

        LastName(string value) : base(value) { }
    }

    public sealed class EMail : KindOf<string>
    {
        public static Result<EMail> Create(string value)
        {
            if (!value.Contains("@"))
            {
                return $"email format is wrong";
            }

            return new EMail(value);
        }

        EMail(string value) : base(value) { }
    }

    public sealed record Name
    {
        public static Result<Name> Create(FirstName firstName, LastName lastName)
        {
            if (firstName.Value == "John" && lastName.Value == "Doe")
            {
                return "John Doe is a blacklisted name";
            }

            return new Name(firstName, lastName);
        }

        Name(FirstName firstName, LastName lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public FirstName FirstName { get; }
        public LastName LastName { get; }
    }

    public sealed class Person
    {
        public static Result<Person> Create(Name name, EMail eMail)
        {
            if (!eMail.Value.Contains(name.LastName))
            {
                return "email must contain last name";
            }

            return new Person(name, eMail);
        }

        Person(Name name, EMail eMail)
        {
            Name = name;
            EMail = eMail;
        }

        public Name Name { get; }
        public EMail EMail { get; }
    }
}
