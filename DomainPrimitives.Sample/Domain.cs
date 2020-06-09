using DomainPrimitives.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvSoft.DomainPrimitives
{
    public static class Domain
    {
        public delegate CreationResult<T> Creator<T, TIn1>(TIn1 param1);
        public delegate CreationResult<T> Creator<T, TIn1, TIn2>(TIn1 param1, TIn2 param2);

        public static CreationResult<T> TryCreate<T, TIn1, TIn2>(this Creator<T, TIn1, TIn2> creator, CreationResult<TIn1> creationResult1, CreationResult<TIn2> creationResult2)
        {
            var childErrors = new List<Error>(2);

            if (creationResult1 is CreationResult<TIn1>.Failure failure1)
            {
                childErrors.Add(failure1.Error);
            }            
            
            if (creationResult2 is CreationResult<TIn2>.Failure failure2)
            {
                childErrors.Add(failure2.Error);
            }

            if (childErrors.Any())
            {
                return new CreationResult<T>.Failure(new Error("tbd", "could not create all necessary parameters", childErrors));
            }

            return creator(((CreationResult<TIn1>.Success)creationResult1).Instance, ((CreationResult<TIn2>.Success)creationResult2).Instance);
        }
    }
}
