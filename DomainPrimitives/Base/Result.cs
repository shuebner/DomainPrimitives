using System.Collections.Immutable;

namespace SvSoft.DomainPrimitives
{
    public abstract record Result<T>
    {
        Result() { }

        public sealed record Ok(T Item) : Result<T>;
        public sealed record Failure(ImmutableArray<Error> Errors) : Result<T>;

        public static implicit operator Result<T>(T Item) => new Ok(Item);
        public static implicit operator Result<T>(string errorMessage) => new Failure(ImmutableArray.Create<Error>(errorMessage));
    }

    public record Error(string Message, ImmutableArray<Error> ChildErrors)
    {
        public static implicit operator Error(string errorMessage) => new(errorMessage, ImmutableArray<Error>.Empty);
    }
}
