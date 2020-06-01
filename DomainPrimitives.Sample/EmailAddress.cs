using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SvSoft.DomainPrimitives.Sample
{
    public sealed class EmailAddress : KindOfString
    {
        public EmailAddress(string value)
            : base(value,
                    Validators.AllOf(
                        StringValidators.SingleLine,
                        StringValidators.NoWhitespace),
                    StringCanonicalizers.LowerCase(CultureInfo.InvariantCulture))
        {
        }
    }
}
