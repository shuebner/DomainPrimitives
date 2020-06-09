using System;
using System.Collections.Generic;
using System.Text;

namespace SvSoft.DomainPrimitives
{
    public static class ValidationResultExtensions
    {
        public static T Match<TValue, T>(this ValidationResult<TValue> result, Func<T> onSuccess, Func<ValidationResult<TValue>.Failure, T> onError) =>
               result is ValidationResult<TValue>.Failure error
                   ? onError(error)
                   : onSuccess();
    }
}
