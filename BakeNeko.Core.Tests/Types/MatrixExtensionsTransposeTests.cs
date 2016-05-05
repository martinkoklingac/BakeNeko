using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixExtensionsTransposeTests
    {
        #region TESTS
        [TestMethod]
        public void MatrixExtensions_Transpose_UnitMatrixTranspose_Test()
        {
            //Arrange
            var mUnit = new Matrix<Integer>(new Integer[1, 1] { { 33 } });

            //Act
            var mActual = mUnit.Transpose();

            //Assert
            Assert.AreEqual(mUnit, mActual);
        }

        [TestMethod]
        public void MatrixExtensions_Transpose_IdentityTransposedIsIdentity_Test()
        {
            //Arrange
            var mIdentity = MatrixExtensions.Identity<Integer>(5);
            var mIdentityExpected = MatrixExtensions.Identity<Integer>(5);

            //Act
            var mActual = mIdentity.Transpose();

            //Assert
            Assert.AreEqual(mIdentityExpected, mActual);
        }

        [TestMethod]
        public void MatrixExtensions_Transpose_ColumnMatrixBecomesRowMatrix_Test()
        {
            //Arrange
            var mColumn = new Matrix<Integer>(new Integer[3, 1] { { 1 }, { 2 }, { 3 } });
            var mExpected = new Matrix<Integer>(new Integer[1, 3] { { 1, 2, 3 } });

            //Act
            var mActual = mColumn.Transpose();

            //Assert
            Assert.AreEqual(mExpected, mActual);
        }

        [TestMethod]
        public void MatrixExtensions_Transpose_RowMatrixBecomesColumnMatrix_Test()
        {
            //Arrange
            var mRow = new Matrix<Integer>(new Integer[1, 3] { { 1, 2, 3 } });
            var mExpected = new Matrix<Integer>(new Integer[3, 1] { { 1 }, { 2 }, { 3 } });

            //Act
            var mActual = mRow.Transpose();

            //Assert
            Assert.AreEqual(mExpected, mActual);
        }

        [TestMethod]
        public void MatrixExtensions_Transpose_NonTrivialTranspose_Test()
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
                ┌───┬───┬───┬───┐
                | 1 | 0 | 9 | 6 |
                ├───┼───┼───┼───┤
                | 7 | 9 | 0 | 1 |
                ├───┼───┼───┼───┤
                | 0 | 0 | 4 | 8 |
                └───┴───┴───┴───┘
            */
            var mExpected = new Matrix<Integer>(new Integer[4, 3]
            {
                {1, 7, 0 },
                {0, 9, 0 },
                {9, 0, 4 },
                {6, 1, 8 }
            });

            //Act
            var mActual = m.Transpose();

            //Assert
            Assert.AreEqual(mExpected, mActual);
        }
        #endregion
    }
}
