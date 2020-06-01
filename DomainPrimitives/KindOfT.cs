using System;

namespace SvSoft.DomainPrimitives
{
    public abstract class KindOf<T>
        where T : class
    {
        private readonly T Value;

        public KindOf(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override bool Equals(object obj) =>
            obj != null &&
            obj.GetType() == GetType() &&
            Equals(Value, ((KindOf<T>)obj).Value);

        public override int GetHashCode() =>
            HashCode.Combine(GetType(), Value);

        public static implicit operator T(KindOf<T> kindOfT) => kindOfT.Value;
    }
}
