using SvSoft.DomainPrimitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SvSoft.DomainPrimitives.Sample
{
    public sealed class Name : KindOfString
    {
        public Name(string value)
            : base(value,
                  Validators.AllOf(
                      StringValidators.MinLength(2),
                      StringValidators.MaxLength(50),
                      StringValidators.SingleLine,
                      StringValidators.NoWhitespace),
                  Canonicalizers.None<string>())
        {
        }
    }
}
