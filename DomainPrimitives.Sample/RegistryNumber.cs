using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SvSoft.DomainPrimitives.Sample
{
    public sealed class RegistryNumber : KindOf<string>
    {
        public RegistryNumber(string value)
            : base(value)
        {
            if (!Regex.IsMatch(value, "^[0-9|A-Z]{9}$"))
            {
                throw new ArgumentException("must be 9-digit alphanumeric string", nameof(value));
            }
        }
    }
}
