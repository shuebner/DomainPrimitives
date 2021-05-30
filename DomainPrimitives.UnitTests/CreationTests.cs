using DomainPrimitives.Sample2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SvSoft.DomainPrimitives
{
    public class CreationTests
    {
        [Fact]
        public void Create_Successfully()
        {
            Result<Person> personResult = Create.From(Person.Create,
                Create.From(Name.Create,
                    FirstName.Create("John"),
                    LastName.Create("Miller")),
                EMail.Create("john@miller.com"));
        }

        [Fact]
        public void Create_WithError()
        {
            Result<Person> personResult = Create.From(Person.Create,
                Create.From(Name.Create,
                    FirstName.Create("John"),
                    LastName.Create("Doe")),
                EMail.Create("john@doe.com"));
        }
    }
}
