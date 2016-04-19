namespace BakeNeko.Core.Types
{
    public static class MatrixExtensions
    {
        public static Matrix<T> Indentity<T>(this T identity, ulong size) 
            where T : struct
        {
            var matrixArray = new T[size, size];
            var width = matrixArray.GetLength(0);
            var height = matrixArray.GetLength(1);

            for (int h = 0; h < height; h++)
                for (int w = 0; w < width; w++)
                    matrixArray[w, h] = w == h ? identity : default(T);

            return new Matrix<T>(matrixArray);
        }
    }
}
