namespace BakeNeko.Core.Types
{
    public static class MatrixExtensions
    {
        public static Matrix<T> Indentity<T>(ulong size)
            where T : INumeric<T>, new()
        {
            var matrixArray = new T[size, size];
            var width = matrixArray.GetLength(0);
            var height = matrixArray.GetLength(1);

            for (int h = 0; h < height; h++)
                for (int w = 0; w < width; w++)
                {
                    var num = new T();
                    matrixArray[w, h] = w == h ? num.Identity() : num;
                }

            var matrix = new Matrix<T>(matrixArray);
            return matrix;
        }
    }
}
