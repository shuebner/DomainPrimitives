using System;
using System.Diagnostics;

namespace SvSoft.DomainPrimitives
{
    [DebuggerDisplay("{value} <{this.GetType().Name,nq}>")]
    public abstract class KindOf<T>
    {
        private readonly T value;

        protected KindOf(T value)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override bool Equals(object obj) =>
            obj != null &&
            obj.GetType() == GetType() &&
            Equals(value, ((KindOf<T>)obj).value);

        public override int GetHashCode() =>
            HashCode.Combine(GetType(), value);

        public override string ToString() => value.ToString();

        public static implicit operator T(KindOf<T> kindOfT) => kindOfT.value;

        public static bool operator ==(KindOf<T> left, KindOf<T> right) =>
            left is null
                ? right is null
                : left.Equals(right);

        public static bool operator !=(KindOf<T> left, KindOf<T> right) => !(left == right);
    }
}
