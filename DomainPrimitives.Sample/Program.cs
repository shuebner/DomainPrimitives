using SvSoft.DomainPrimitives;
using System;

namespace DomainPrimitives.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawNameInput = "invalid name candidate\n";
            string rawEmailInput = "raw@email.input";

            CreationResult<Person> result = Domain.TryCreate(Person.Create,
                Name.Create(rawNameInput),
                EmailAddress.Create(rawEmailInput));        }
    }
}
