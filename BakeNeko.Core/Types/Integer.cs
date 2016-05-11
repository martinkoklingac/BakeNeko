namespace BakeNeko.Core.Types
{
    public class Integer :
       INumeric<Integer>
    {
        #region PRIVATE FIELDS
        private readonly long _value;
        #endregion

        #region CONSTRUCTORS
        public Integer() { _value = 0; }
        public Integer(short value) { _value = value; }
        public Integer(int value) { _value = value; }
        public Integer(long value) { _value = value; }
        public Integer(Integer value) { _value = value._value; }
        #endregion

        #region PUBLIC METHODS
        public override int GetHashCode() { return this._value.GetHashCode(); }
        public override bool Equals(object obj)
        {
            var integer = obj as Integer;
            return integer != null && this._value.Equals(integer._value);
        }
        public override string ToString(){ return this._value.ToString(); }

        public static Integer Identity() { return new Integer(1); }
        public static Integer Zero() { return new Integer(0); }

        #region INTERFACE INumeric<Integer>
        Integer INumeric<Integer>.Identity() { return Integer.Identity(); }
        Integer INumeric<Integer>.Zero() { return Integer.Zero(); }

        public Integer Add(long a) { return this.Add(new Integer(a)); }
        public Integer Add(Integer a) { return new Integer(this._value + a._value); }
        public Integer Subtract(long a) { return this.Subtract(new Integer(a)); }
        public Integer Subtract(Integer a) { return new Integer(this._value - a._value); }
        public Integer Multiply(long a) { return this.Multiply(new Integer(a)); }
        public Integer Multiply(Integer a) { return new Integer(this._value * a._value); }
        public Integer Divide(long a) { return this.Divide(new Integer(a)); }
        public Integer Divide(Integer a) { return new Integer(this._value / a._value); }
        #endregion
        #endregion

        #region OPERATORS
        public static Integer operator +(Integer a, Integer b) { return a.Add(b); }
        public static Integer operator -(Integer a, Integer b) { return a.Subtract(b); }
        public static Integer operator *(Integer a, Integer b) { return a.Multiply(b); }
        public static Integer operator /(Integer a, Integer b) { return a.Divide(b); }

        public static implicit operator Integer(short a) { return new Integer(a); }
        public static implicit operator Integer(int a) { return new Integer(a); }
        public static implicit operator Integer(long a) { return new Integer(a); }
        public static implicit operator decimal(Integer a) { return a._value; }
        public static implicit operator double(Integer a) { return a._value; }
        public static implicit operator float(Integer a) { return a._value; }
        public static implicit operator long(Integer a) { return a._value; }
        public static explicit operator short(Integer a) { return (short)a._value; }
        public static explicit operator int(Integer a) { return (int)a._value; }
        #endregion
    }
}
