using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixEqualityTests
    {
        [TestMethod]
        public void Matrix_Equals_OneByOneZeroEquality_Test()
        {
            //Arrange
            var zeroOneByOneArrayA = new Integer[1, 1] { { 0 } };
            var zeroOneByOneArrayB = new Integer[1, 1] { { 0 } };
            var matrixA = new Matrix<Integer>(zeroOneByOneArrayA);
            var matrixB = new Matrix<Integer>(zeroOneByOneArrayB);

            //Assert
            Assert.AreEqual(matrixA, matrixB);
        }

        [TestMethod]
        public void Matrix_Equals_OneByOneIdentityEquality_Test()
        {
            //Arrange
            var zeroOneByOneArrayA = new Integer[1, 1] { { Integer.Identity() } };
            var zeroOneByOneArrayB = new Integer[1, 1] { { Integer.Identity() } };
            var matrixA = new Matrix<Integer>(zeroOneByOneArrayA);
            var matrixB = new Matrix<Integer>(zeroOneByOneArrayB);

            //Assert
            Assert.AreEqual(matrixA, matrixB);
        }

        [TestMethod]
        public void Matrix_Equals_SquareMatrixEquality_Test()
        {
            //Arrange
            var squareArrayA = new Integer[5, 5]
            {
                {1, 2, 3, 4, 5 },
                {34, 56, 43, 12, 11 },
                {3, 2, 1, 4, 6 },
                {1, 1, 1, 1, 1 },
                {0, 0, 0, 0, 0 }
            };

            var squareArrayB = new Integer[5, 5]
            {
                {1, 2, 3, 4, 5 },
                {34, 56, 43, 12, 11 },
                {3, 2, 1, 4, 6 },
                {1, 1, 1, 1, 1 },
                {0, 0, 0, 0, 0 }
            };

            var matrixA = new Matrix<Integer>(squareArrayA);
            var matrixB = new Matrix<Integer>(squareArrayB);

            //Assert
            Assert.AreEqual(matrixA, matrixB);
        }

        [TestMethod]
        public void Matrix_Equals_SquareMatrixInequality_Test()
        {
            //Arrange
            var squareArrayA = new Integer[5, 5]
            {
                {1, 2, 3, 4, 5 },
                {34, 56, 43, 12, 11 },
                {3, 2, 1, 4, 6 },
                {1, 1, 1, 1, 1 },
                {0, 0, 0, 0, 0 }
            };

            var squareArrayB = new Integer[5, 5]
            {
                {1, 2, 3, 4, 5 },
                {34, 56, 43, 12, 11 },
                {3, 2, 1, 4, 6 },
                {1, 1, 1, 1, 1 },
                {0, 0, 777, 0, 0 }
            };

            var matrixA = new Matrix<Integer>(squareArrayA);
            var matrixB = new Matrix<Integer>(squareArrayB);

            //Assert
            Assert.AreNotEqual(matrixA, matrixB);
        }

        [TestMethod]
        public void Matrix_Equals_SizeInequality_Width_Test()
        {
            //Arrange
            var squareArrayA = new Integer[5, 5]
            {
                {0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0 },
            };

            var squareArrayB = new Integer[5, 4]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };

            var matrixA = new Matrix<Integer>(squareArrayA);
            var matrixB = new Matrix<Integer>(squareArrayB);

            //Assert
            Assert.AreNotEqual(matrixA, matrixB);
        }
    }
}
