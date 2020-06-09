using System;
using System.Collections.Generic;
using System.Text;

namespace SvSoft.DomainPrimitives
{
    public class ValidationResult
    {
        public static ValidationResult<T> Success<T>() => new ValidationResult<T>.Success();

        public static ValidationResult<T> Failure<T>(string errorMessage, T invalidValue) =>
            new ValidationResult<T>.Failure(errorMessage, invalidValue);
    }

    public abstract class ValidationResult<T>
    {
        private ValidationResult()
        {
        }

        public sealed class Success
            : ValidationResult<T>
        {
            public Success()
            {
            }
        }

        public sealed class Failure
            : ValidationResult<T>
        {
            public readonly string ErrorMessage;
            public readonly T OriginalValue;

            public Failure(string errorMessage, T invalidValue)
            {
                ErrorMessage = errorMessage;
                OriginalValue = invalidValue;
            }
        }
    }
}
