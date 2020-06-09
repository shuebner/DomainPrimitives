using SvSoft.DomainPrimitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DomainPrimitives.Sample
{
    public sealed class EmailAddress : KindOfString
    {
        public static CreationResult<EmailAddress> Create(string emailAddress)
        {
            return new CreationResult<EmailAddress>.Success(new EmailAddress(emailAddress));
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
