using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvSoft.DomainPrimitives
{
    public static class Validators
    {
        public static Func<T, ValidationResult<T>> AllOf<T>(params Func<T, ValidationResult<T>>[] validators) =>
            str => validators
                .Select(validate => validate(str))
                .FirstOrDefault(result => result is ValidationResult<T>.Failure) is ValidationResult<T>.Failure error
                    ? error
                    : ValidationResult.Success<T>();

        public static Func<T, ValidationResult<T>> None<T>() => str => ValidationResult.Success<T>();
    }
}
