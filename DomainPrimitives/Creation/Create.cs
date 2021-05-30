using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SvSoft.DomainPrimitives
{
    public static class Create
    {
        public static Result<TResult> From<TIn0, TIn1, TResult>(
            Func<TIn0, TIn1, Result<TResult>> create,
            Result<TIn0> arg0Result,
            Result<TIn1> arg1Result)
        {
            if (arg0Result is Result<TIn0>.Ok { Item: var arg0 } &&
                arg1Result is Result<TIn1>.Ok { Item: var arg1 })
            {
                return create(arg0, arg1);
            }

            var parameters = create.Method.GetParameters();
            List<Error> errors = new();

            AddErrors(arg0Result, parameters[0], errors);
            AddErrors(arg1Result, parameters[1], errors);

            return new Result<TResult>.Failure(errors.ToImmutableArray());
        }

        public static Result<(TIn0, TIn1)> From<TIn0, TIn1, TResult>(
            Result<TIn0> arg0Result,
            Result<TIn1> arg1Result)
        {
            if (arg0Result is Result<TIn0>.Ok { Item: var arg0 } &&
                arg1Result is Result<TIn1>.Ok { Item: var arg1 })
            {
                return (arg0, arg1);
            }

            List<Error> errors = new();

            AddErrors(arg0Result, 0, errors);
            AddErrors(arg1Result, 1, errors);

            return new Result<(TIn0, TIn1)>.Failure(errors.ToImmutableArray());
        }

        static void AddErrors<T>(Result<T> result, ParameterInfo parameterInfo, ICollection<Error> errors)
        {
            if (result is Result<T>.Failure { Errors: var resultErrors })
            {
                errors.Add(new($"parameter '{parameterInfo.Name}' of type {parameterInfo.ParameterType.Name} was not supplied", resultErrors));
            }
        }

        static void AddErrors<T>(Result<T> result, int paramIndex, ICollection<Error> errors)
        {
            if (result is Result<T>.Failure { Errors: var resultErrors })
            {
                errors.Add(new($"parameter '{paramIndex}' of type {typeof(T).Name} was not supplied", resultErrors));
            }
        }
    }
}
