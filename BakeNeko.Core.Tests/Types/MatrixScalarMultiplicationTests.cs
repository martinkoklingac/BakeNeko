using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixScalarMultiplicationTests
    {
        #region TESTS
        [TestMethod]
        public void Matrix_ScalarMultiplication_UnitMatrixTimesIdentityIsUnitMatrix_Test()
        {
            //Arrange
            var mUnit = new Matrix<Integer>(new Integer[1, 1] { { 34 } });
            var mExpected = new Matrix<Integer>(new Integer[1, 1] { { 34 } });

            //Act
            var mActual = 1 * mUnit;

            //Assert
            Assert.AreEqual(mExpected, mActual);
        }

        [TestMethod]
        public void Matrix_ScalarMultiplication_UnitMatrixTimesZeroIsZeroMatrix_Test()
        {
            //Arrange
            var mUnit = new Matrix<Integer>(new Integer[1, 1] { { 34 } });
            var mExpected = new Matrix<Integer>(1);

            //Act
            var mActual = 0 * mUnit;

            //Assert
            Assert.AreEqual(mExpected, mActual);
        }

        [TestMethod]
        public void Matrix_ScalarMultiplication_NonTrivialMatrixTimesArbitraryNonZeroConstant_Test()
        {
            //Arrange
            /*  
                ┌───┬───┬───┐
                | 1 | 7 | 0 |
                ├───┼───┼───┤
                | 0 | 9 | 0 |
                ├───┼───┼───┤
                | 9 | 0 | 4 |
                ├───┼───┼───┤
                | 6 | 1 | 8 |
                └───┴───┴───┘
            */
            var m = new Matrix<Integer>(new Integer[3, 4]
            {
                {1, 0, 9, 6 },
                {7, 9, 0, 1 },
                {0, 0, 4, 8 }
            });

            /*  
                ┌────┬────┬────┐
                |  3 | 21 |  0 |
                ├────┼────┼────┤
                |  0 | 27 |  0 |
                ├────┼────┼────┤
                | 27 |  0 | 12 |
                ├────┼────┼────┤
                | 18 |  3 | 24 |
                └────┴────┴────┘
            */
            var mExpected = new Matrix<Integer>(new Integer[3, 4]
            {
                {3, 0, 27, 18 },
                {21, 27, 0, 3 },
                {0, 0, 12, 24 }
            });

            //Act
            var mActual = 3 * m;

            //Assert
            Assert.AreEqual(mExpected, mActual);
        }
        #endregion
    }
}
