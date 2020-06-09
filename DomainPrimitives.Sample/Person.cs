namespace DomainPrimitives.Sample
{
    public class Person
    {
        public static CreationResult<Person> Create(Name name, EmailAddress emailAddress)
        {
            return new CreationResult<Person>.Success(new Person(name, emailAddress));
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
