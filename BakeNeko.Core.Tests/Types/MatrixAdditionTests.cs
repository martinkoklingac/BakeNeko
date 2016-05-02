using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixAdditionTests
    {
        #region PRIVATE FIELDS
        #endregion

        #region SETUP / TEARDOWN
        #endregion

        #region TESTS
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Matrix_Addition_NonConformableMatricesCannotBeAdded_Test()
        {
            //Setup
            var mA = new Matrix<Integer>(new Integer[3, 6]);
            var mB = new Matrix<Integer>(new Integer[4, 5]);

            //Act
            var mc = mA + mB;
        }

        [TestMethod]
        public void Matrix_Addition_OneByOneMatrixAddition_Test()
        {
            //Setup
            var mA = new Matrix<Integer>(new Integer[,] { { 1 } });
            var mB = new Matrix<Integer>(new Integer[,] { { 2 } });

            var matrixExpected = new Matrix<Integer>(new Integer[,] { { 3 } });

            //Act
            var mC = mA + mB;

            //Assert
            Assert.AreEqual(matrixExpected, mC);
        }

        [TestMethod]
        public void Matrix_Addition_HorizontalMatrixAddition_Test()
        {
            //Setup
            var mA = new Matrix<Integer>(new Integer[3, 1] { { 1 }, { 2 }, { -3 } });
            var mB = new Matrix<Integer>(new Integer[3, 1] { { 4 }, { 7 }, { -8 } });

            var matrixExpected = new Matrix<Integer>(new Integer[3, 1] { { 5 }, { 9 }, { -11 } });

            //Act
            var mC = mA + mB;

            //Assert
            Assert.AreEqual(matrixExpected, mC);
        }

        [TestMethod]
        public void Matrix_Addition_VerticalMatrixAddition_Test()
        {
            //Setup
            var mA = new Matrix<Integer>(new Integer[1, 3] { { 1, 2, 3 } });
            var mB = new Matrix<Integer>(new Integer[1, 3] { { -34, -5, 6 } });

            var matrixExpected = new Matrix<Integer>(new Integer[1, 3] { { -33, -3, 9 } });

            //Act
            var mC = mA + mB;

            //Assert
            Assert.AreEqual(matrixExpected, mC);
        }

        [TestMethod]
        public void Matrix_Addition_SquareMatrixAddition_Test()
        {
            //Setup
            var mA = new Matrix<Integer>(new Integer[,] { { 1, 2 }, { -3, 4 } });
            var mB = new Matrix<Integer>(new Integer[,] { { 7, -7 }, { 8, 8 } });

            var matrixExpected = new Matrix<Integer>(new Integer[,] { { 8, -5 }, { 5, 12 } });

            //Act
            var mC = mA + mB;

            //Assert
            Assert.AreEqual(matrixExpected, mC);
        }

        [TestMethod]
        public void Matrix_Addition_RectangularMatrixAddition_Test()
        {
            //Setup
            var mA = new Matrix<Integer>(new Integer[,] { { 1, 2, -100 }, { -3, 4, -23 } });
            var mB = new Matrix<Integer>(new Integer[,] { { 7, -7, 54 }, { 8, 8, 8 } });

            var matrixExpected = new Matrix<Integer>(new Integer[,] { { 8, -5, -46 }, { 5, 12, -15 } });

            //Act
            var mC = mA + mB;

            //Assert
            Assert.AreEqual(matrixExpected, mC);
        }
        #endregion
    }
}
