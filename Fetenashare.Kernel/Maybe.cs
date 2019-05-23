using System;

namespace Fetenashare.Kernel
{
    public struct Maybe<T> : IEquatable<Maybe<T>> where T : class
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (HasNoValue) throw new InvalidOperationException();

                return _value;
            }
        }

        public bool HasValue => _value != null;

        public bool HasNoValue => !HasValue;

        private Maybe(T value)
        {
            _value = value;
        }

        public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (maybe != null && maybe.HasNoValue) return false;

            return maybe != null && maybe.Value.Equals(value);
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first != null && first.Equals(second);
        }

        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == value);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Maybe<T>)) return false;

            var other = (Maybe<T>)obj;
            return Equals(other);
        }

        public bool Equals(Maybe<T> other)
        {
            if (HasNoValue && other.HasNoValue) return true;

            if (HasNoValue || other.HasNoValue) return false;

            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return HasNoValue ? "None" : Value.ToString();
        }
    }
}
