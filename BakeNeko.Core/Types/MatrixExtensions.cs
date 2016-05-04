using System;

namespace BakeNeko.Core.Types
{
    public static class MatrixExtensions
    {
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

        public static Matrix<T> Inverse<T>(this Matrix<T> m)
            where T : INumeric<T>, new()
        {
            throw new NotImplementedException();
        }
    }
}
