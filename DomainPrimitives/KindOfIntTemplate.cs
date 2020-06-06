using System;
using System.Diagnostics;

namespace SvSoft.DomainPrimitives
{
    [DebuggerDisplay("{value} ({this.GetType().Name})")]
    public readonly struct KindOfIntTemplate :
        IEquatable<KindOfIntTemplate>,
        IComparable<KindOfIntTemplate>
    {
        private readonly int value;

        public KindOfIntTemplate(int value)
        {
            this.value = value;
        }

        public override bool Equals(object obj) =>
            obj is KindOfIntTemplate kindOfInt &&
            value == kindOfInt.value;

        public override int GetHashCode() =>
            HashCode.Combine(typeof(KindOfIntTemplate), value);

        public override string ToString() => value.ToString();

        public bool Equals(KindOfIntTemplate other) =>
            value == other.value;

        public int CompareTo(KindOfIntTemplate other) =>
            value.CompareTo(other.value);

        public static implicit operator int(KindOfIntTemplate kindOfInt) => kindOfInt.value;

        public static bool operator ==(KindOfIntTemplate left, KindOfIntTemplate right) =>
            left.Equals(right);

        public static bool operator !=(KindOfIntTemplate left, KindOfIntTemplate right) =>
            !(left == right);

        public static bool operator <(KindOfIntTemplate left, KindOfIntTemplate right) =>
            left.CompareTo(right) < 0;

        public static bool operator <=(KindOfIntTemplate left, KindOfIntTemplate right) =>
            left.CompareTo(right) <= 0;

        public static bool operator >(KindOfIntTemplate left, KindOfIntTemplate right) =>
            left.CompareTo(right) > 0;

        public static bool operator >=(KindOfIntTemplate left, KindOfIntTemplate right) =>
            left.CompareTo(right) >= 0;
    }
}
