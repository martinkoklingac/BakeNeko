using System;
namespace BakeNeko.Core.Types
{
    public class MatrixDimensionException : 
        Exception
    {
        public MatrixDimensionException(string message) : base(message) { }
    }
}
