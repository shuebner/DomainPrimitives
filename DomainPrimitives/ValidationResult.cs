using System;
using System.Collections.Generic;
using System.Text;

namespace SvSoft.DomainPrimitives
{
    public class ValidationResult
    {
        public static ValidationResult<T> Success<T>() => new ValidationResult<T>.SuccessResult();

        public static ValidationResult<T> Error<T>(string errorMessage, T invalidValue) =>
            new ValidationResult<T>.ErrorResult(errorMessage, invalidValue);
    }

    public abstract class ValidationResult<T>
    {
        private ValidationResult()
        {
        }

        public class SuccessResult
            : ValidationResult<T>
        {
            internal SuccessResult()
            {
            }
        }

        public class ErrorResult
            : ValidationResult<T>
        {
            public readonly string ErrorMessage;
            public readonly T OriginalValue;

            internal ErrorResult(string errorMessage, T invalidValue)
            {
                ErrorMessage = errorMessage;
                OriginalValue = invalidValue;
            }
        }
    }
}
