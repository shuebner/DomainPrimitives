using System;
using System.Collections.Generic;
using System.Text;

namespace SvSoft.DomainPrimitives
{
    public class KindOfString : KindOf<string>
    {
        public KindOfString(string value, Func<string, ValidationResult<string>> validate, Func<string, string> canonicalize)
            : base(
                validate(value).Match(
                    () => canonicalize(value),
                    error => throw new ArgumentException(
                        string.Join("\n", error.ErrorMessage, $"original value: {error.OriginalValue}"),
                        nameof(value))))
        {
        }
    }
}
