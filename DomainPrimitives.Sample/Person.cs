using SvSoft.DomainPrimitives;

namespace DomainPrimitives.Sample
{
    public class Person
    {
        public static Result<Person> Create(Name name, EmailAddress emailAddress)
        {
            return new Person(name, emailAddress);
        }

        private Person(Name name, EmailAddress email)
        {
            Name = name;
            Email = email;
        }

        public Name Name { get; }

        public EmailAddress Email { get; }
    }
}
