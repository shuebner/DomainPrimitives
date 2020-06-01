using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SvSoft.DomainPrimitives
{
    public static class StringCanonicalizers
    {
        public static Func<string, string> Trim => str => str.Trim();

        public static Func<string, string> LowerCase(CultureInfo culture) => str => str.ToLower(culture);
    }
}
