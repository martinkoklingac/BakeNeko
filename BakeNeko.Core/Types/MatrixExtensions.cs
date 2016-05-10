using System;

namespace BakeNeko.Core.Types
{
    public static class MatrixExtensions
    {
        /// <summary>
        /// Generates a nXn identity Matrix where n is given by parameter size.
        /// </summary>
        /// <typeparam name="T">Type of Matrix entries</typeparam>
        /// <param name="size">Width & Height of the generated square Matrix</param>
        /// <returns>new Matrix instance</returns>
        public static Matrix<T> Identity<T>(ulong size)
            where T : INumeric<T>, new()
        {
            var m = new Matrix<T>(size);
            for (var row = 0ul; row < m.Height; row++)
                for (var col = 0ul; col < m.Width; col++)
                    if (col == row)
                        m[col, row] = new T().Identity();

            return m;
        }

        public static Matrix<T> Transpose<T>(this Matrix<T> m)
            where T : INumeric<T>, new()
        {
            var mt = new Matrix<T>(m.Height, m.Width);
            for (var row = 0ul; row < mt.Height; row++)
                for (var col = 0ul; col < mt.Width; col++)
                    mt[col, row] = m[row, col];

            return mt;
        }

        /// <summary>
        /// Calculates the determinant of an nXn square Matrix.
        /// </summary>
        /// <typeparam name="T">Type of Matrix entries</typeparam>
        /// <param name="m">Matrix instance</param>
        /// <returns>Determinant of type T</returns>
        public static T Determinant<T>(this Matrix<T> m)
             where T : INumeric<T>, new()
        {
            if (m.Width != m.Height)
                throw new InvalidOperationException("Matrix m must be square");

            var size = m.Width;
            if(size == 2)
            {
                var a = m[0, 0];
                var b = m[1, 0];

                var c = m[0, 1];
                var d = m[1, 1];

                var ad = a.Multiply(d);
                var bc = b.Multiply(c);
                var determinant = ad.Subtract(bc);
                return determinant;
            }

            throw new NotImplementedException();
        }

        public static Matrix<T> Inverse<T>(this Matrix<T> m)
            where T : INumeric<T>, new()
        {
            throw new NotImplementedException();
        }
    }
}
