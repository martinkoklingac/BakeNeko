using System;

namespace BakeNeko.Core.Types
{
    public class Matrix<T> 
        where T : INumeric<T>, new()
    {
        #region PRIVATE FIELDS
        private readonly T[,] _matrix;
        #endregion

        #region CONSTRUCTORS
        public Matrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            if (matrix.GetUpperBound(0) < 0)
                throw new MatrixDimensionException("Matrix width cannot be less then 1");

            if (matrix.GetUpperBound(1) < 0)
                throw new MatrixDimensionException("Matrix height cannot be less then 1");

            _matrix = matrix;
        }
        #endregion

        #region PUBLIC PROPERTIES
        public ulong Width { get { return (ulong)this._matrix.GetLongLength(0); } }
        public ulong Height { get { return (ulong)this._matrix.GetLongLength(1); } }
        public bool IsSquare { get { return this.Width == this.Height; } }

        public T this[ulong col, ulong row]
        {
            get { return _matrix[col,row]; }
            set { _matrix[col, row] = value; }
        }
        #endregion

        #region PUBLIC METHODS
        public override int GetHashCode()
        {
            //TODO : Need to calculate this hash based on contents
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix<T>;
            if (matrix == null
                || matrix.Width != this.Width
                || matrix.Height != this.Height)
                return false;

            for (var row = 0ul; row < this.Height; row++)
                for (var col = 0ul; col < this.Width; col++)
                    if (!this[col, row].Equals(matrix[col, row]))
                        return false;

            return true;
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if (a.Width != b.Width)
                throw new InvalidOperationException(string.Format("Matrices do not have same width: a.Width={0} != b.Width={1}", a.Width, b.Width));

            if(a.Height != b.Height)
                throw new InvalidOperationException(string.Format("Matrices do not have same height: a.Height={0} != b.Height={1}", a.Height, b.Height));

            var result = new Matrix<T>(new T[a.Width, a.Height]);

            for (var row = 0ul; row < a.Height; row++)
                for (var col = 0ul; col < a.Width; col++)
                    result[col, row] = a[col, row].Add(b[col, row]);

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
