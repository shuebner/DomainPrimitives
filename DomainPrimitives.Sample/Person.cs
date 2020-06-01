using SvSoft.DomainPrimitives.Sample;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainPrimitives.Sample
{
    public class Person
    {
        public Person(Name name, EmailAddress email)
        {
            Name = name;
            Email = email;
        }

        public Name Name { get; }

        public EmailAddress Email { get; }
    }
}
