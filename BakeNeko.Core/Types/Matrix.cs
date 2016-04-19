using System;

namespace BakeNeko.Core.Types
{
    public class Matrix<T> 
        where T : struct
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

        public T this[ulong width, ulong height]
        {
            get { return _matrix[width,height]; }
            set { _matrix[width, height] = value; }
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Creates a square identity matrix 
        /// where width & height are equal to size.
        /// </summary>
        /// <param name="size">Width & Height of resulting identity matrix</param>
        /// <param name="identity"></param>
        /// <returns>Square identity matrix</returns>
        public static Matrix<T> Identity(ulong size, T identity)
        {
            var matrix = new Matrix<T>(new T[size, size]);
            for (ulong h = 0; h < matrix.Height; h++)
                for (ulong w = 0; w < matrix.Width; w++)
                    matrix[w, h] = w == h ? identity : default(T);
                
            return matrix;
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            throw new NotImplementedException();
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
