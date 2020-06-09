using SvSoft.DomainPrimitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainPrimitives.Sample
{
    public sealed class Name : KindOfString
    {
        public static CreationResult<Name> Create(string value)
        {
            return new CreationResult<Name>.Success(new Name(value));
        }

        public Name(string value)
            : base(value,
                  Validators.AllOf(
                      StringValidators.MinLength(2),
                      StringValidators.MaxLength(50),
                      StringValidators.SingleLine),
                  Canonicalizers.None<string>())
        {
        }
    }
}
