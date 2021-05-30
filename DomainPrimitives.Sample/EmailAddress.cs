using SvSoft.DomainPrimitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DomainPrimitives.Sample
{
    public sealed class EmailAddress : KindOfString
    {
        public static Result<EmailAddress> Create(string emailAddress)
        {
            return new EmailAddress(emailAddress);
        }

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
