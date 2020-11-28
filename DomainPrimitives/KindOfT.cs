using System;
using System.Diagnostics;

namespace SvSoft.DomainPrimitives
{
    [DebuggerDisplay("{Value} <{this.GetType().Name,nq}>")]
    public abstract class KindOf<T>
    {
        public T Value { get; }

        protected KindOf(T value)
        {
            this.Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override bool Equals(object obj) =>
            obj != null &&
            obj.GetType() == GetType() &&
            Equals(Value, ((KindOf<T>)obj).Value);

        public override int GetHashCode() =>
            HashCode.Combine(GetType(), Value);

        public override string ToString() => Value.ToString();

        public static implicit operator T(KindOf<T> kindOfT) => kindOfT.Value;

        public static bool operator ==(KindOf<T> left, KindOf<T> right) =>
            left is null
                ? right is null
                : left.Equals(right);

        public static bool operator !=(KindOf<T> left, KindOf<T> right) => !(left == right);
    }
}
