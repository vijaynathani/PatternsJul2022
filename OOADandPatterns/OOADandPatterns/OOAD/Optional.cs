using System;
using System.Collections.Generic;

namespace OOADandPatterns.OOAD
{
    /// <summary>
    ///  Similar to Java Optional class.
    ///  See https://docs.oracle.com/javase/8/docs/api/java/util/Optional.html 
    /// </summary>
    public class Optional<T> 
    {
        private readonly bool _isPresent;
        private readonly T _value;

        private Optional(bool isPresent, T value)
        {
            _isPresent = isPresent;
            _value = value;
        }

        public static Optional<T> Empty()
        {
            return new Optional<T>(false, default(T));
        }

        public T Get()
        {
            if (!_isPresent) throw new InvalidOperationException("Get on empty optional?");
            return _value;
        }

        protected bool Equals(Optional<T> other)
        {
            return _isPresent && other._isPresent && EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Optional<T>) obj);
        }

        public override int GetHashCode()
        {
            return _isPresent ? EqualityComparer<T>.Default.GetHashCode(_value) : 1;
        }

        public void IsPresent(Action<T> consumer)
        {
            if (_isPresent) consumer.Invoke(_value);
        }

        public bool IsPresent()
        {
            return _isPresent;
        }

        public static Optional<T> Of(T value)
        {
            if (value == null) throw new ArgumentException("null while creating Optional?");
            return new Optional<T>(true, value);
        }

        public static Optional<T> OfNullable(T value)
        {
            return (value == null) ? Empty() : Of(value);
        }

        public T OrElse(T other)
        {
            return _isPresent ? _value : other;
        }

        public T OrElseGet(Func<T> supplier)
        {
            return _isPresent ? _value : supplier();
        }

        public T OrElseThrow(Func<Exception> exceptionSupplier)
        {
            if (_isPresent) return _value;
            throw (Exception) Activator.CreateInstance(exceptionSupplier.Invoke().GetType());
        }

        public override string ToString()
        {
            if (_isPresent)
                return string.Format("IsPresent: {0}, Value: {1}", _isPresent, _value);
            return string.Format("IsPresent: {0}", _isPresent);
        }

        public Optional<T> Filter(Func<T, bool> predicate)
        {
            return _isPresent && predicate(_value) ? this : Empty();
        }

        public Optional<T2> Map<T2>(Func<T, T2> mapper) where T2 : class
        {
            return !_isPresent ? Optional<T2>.Empty() : Optional<T2>.OfNullable(mapper(_value));
        }

        public Optional<T2> FlatMap<T2>(Func<T, Optional<T2>> mapper) where T2 : class
        {
            return !_isPresent ? Optional<T2>.Empty() : mapper(_value);
        }
    }
}