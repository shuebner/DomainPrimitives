using System.Collections.Immutable;
using System.Diagnostics;

namespace SvSoft.DomainPrimitives
{
    public abstract record Result<T>
    {
        Result() { }

        [DebuggerDisplay("Ok: {Item}")]
        public sealed record Ok(T Item) : Result<T>;

        [DebuggerDisplay("Failure: first error: {Errors[0]}")]
        public sealed record Failure(ImmutableArray<Error> Errors) : Result<T>;

        public static implicit operator Result<T>(T Item) => new Ok(Item);
        public static implicit operator Result<T>(string errorMessage) => new Failure(ImmutableArray.Create<Error>(errorMessage));
    }

    [DebuggerDisplay("{Message}, {ChildErrors.Length} child errors")]
    public record Error(string Message, ImmutableArray<Error> ChildErrors)
    {
        public static implicit operator Error(string errorMessage) => new(errorMessage, ImmutableArray<Error>.Empty);
    }
}
