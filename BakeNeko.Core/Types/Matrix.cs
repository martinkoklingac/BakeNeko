using System;
using System.Text;

namespace BakeNeko.Core.Types
{
    public class Matrix<T> 
        where T : INumeric<T>, new()
    {
        #region PRIVATE FIELDS
        private readonly T[,] _matrix;
        #endregion

        #region CONSTRUCTORS
        public Matrix(ulong size) : this(size, size) { }

        public Matrix(ulong width, ulong height) :
            this(new T[width, height])
        {
            //The underlying array needs to be initialized with 0 values
            for (var row = 0ul; row < this.Height; row++)
                for (var col = 0ul; col < this.Width; col++)
                    this[col, row] = new T();
        }

        /// <summary>
        /// Initializes a Matrix data structure with a n X m array of types T.
        /// The array indexing convention is as follows:
        ///     - First index denotes the matrix width (number of columns)
        ///     - Second index denotes the matrix height (number of rows)
        /// </summary>
        /// <param name="matrix">n X m array of T values</param>
        /// <exception cref="MatrixDimensionException">
        /// Thrown when attempting to initialize the Matrix data structure with
        /// an array where at least one dimension is 0. 
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Initializing array cannot be null.
        /// </exception>
        /// <remarks>
        /// Martix data structure cannot be initialized with an n X m array
        /// where one or both dimensions are 0 since this would result in invalid indexing operations
        /// on the underlying array.
        /// </remarks>
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            for (var row = 0ul; row < this.Height; row++)
            {
                sb.Append("|");
                for (var col = 0ul; col < this.Width; col++)
                    sb.AppendFormat(" {0} |", this[col, row]);

                sb.AppendLine();
            }

            return sb.ToString();
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
            //TODO : Throw some special exception for this case
            if (a.Width != b.Height)
                return null;

            var k = a.Width;
            var resultant = new Matrix<T>(b.Width, a.Height);

            //Traverse the rows and columns of resultant matrix
            for (var row = 0ul; row < resultant.Height; row++)
                for (var col = 0ul; col < resultant.Width; col++)
                    //This might be better expressed as a dot product of two vectors
                    for (var m = 0ul; m < k; m++)
                    {
                        var a1 = a[m, row];
                        var b1 = b[col, m];
                        resultant[col, row] = resultant[col, row]
                            .Add(a1.Multiply(b1));
                    }

            return resultant;
        }
        #endregion
    }
}
