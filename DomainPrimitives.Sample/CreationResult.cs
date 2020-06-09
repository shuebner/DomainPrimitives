using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace DomainPrimitives.Sample
{
    public abstract class CreationResult<T>
    {
        private CreationResult()
        {
        }

        public sealed class Success : CreationResult<T>
        {
            public Success(T instance)
            {
                this.Instance = instance;
            }

            public T Instance { get; }
        }

        [DebuggerDisplay("{Error}")]
        public sealed class Failure : CreationResult<T>
        {
            private readonly string internalMessage;

            public Failure(Error error)
            {
                this.Error = error;
            }

            public Error Error { get; }
        }
    }

    [DebuggerDisplay("{Code}: {internalMessage}")]
    public sealed class Error
    {
        private readonly string internalMessage;

        public Error(string code, string internalMessage)
        {
            this.internalMessage = internalMessage;
            Code = code;
        }

        public Error(string code, string internalMessage, IEnumerable<Error> children)
        {
            this.internalMessage = internalMessage;
            Code = code;
            Children = children.ToImmutableArray();
        }

        public string Code { get; }

        public ImmutableArray<Error> Children { get; } = ImmutableArray<Error>.Empty;
    }
}
