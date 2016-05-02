using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixDimensionsTests
    {
        #region PRIVATE FIELDS
        /*  
            ┌───┬───┐───┐────┐
            | 1 | 2 | 3 | 33 |
            ├───┼───┤───┤────┤
            | 4 | 5 | 6 | 66 |
            ├───┼───┤───┤────┤
            | 7 | 8 | 9 | 99 |
            └───┴───┘───┘────┘
        */
        private static Integer[,] _array4by3;
        #endregion

        #region SETUP / TEARDOWN
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _array4by3 = new Integer[4, 3]
            {
                {1, 4, 7 },
                {2, 5, 8 },
                {3, 6, 9 },
                {33, 66, 99 }
            };
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _array4by3 = null;
        }
        #endregion

        #region TESTS
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Matrix_NullContructorArgCheck_Test()
        {
            //Act
            var matrix = new Matrix<Integer>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixDimensionException))]
        public void Matrix_InvalidWidthCheck_Test()
        {
            //Act
            var matrix = new Matrix<Integer>(new Integer[0, 10]);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixDimensionException))]
        public void Matrix_InvalidHeightCheck_Test()
        {
            //Act
            var matrix = new Matrix<Integer>(new Integer[10, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(MatrixDimensionException))]
        public void Matrix_InvalidWidthAndHeightCheck_Test()
        {
            //Act
            var matrix = new Matrix<Integer>(new Integer[0, 0]);
        }

        [TestMethod]
        public void Matrix_WidthMatchesUnderlyingArrayWidth_Test()
        {
            //Arrange
            const ulong expectedWidth = 10;
            var matrixArray = new Integer[expectedWidth, 20];
            var matrix = new Matrix<Integer>(matrixArray);

            //Act
            var actualWidth = matrix.Width;

            //Assert
            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void Matrix_RightmostEdgeIsAddressable_Test()
        {
            //Arrange
            const ulong expectedWidth = 10;
            var matrixArray = new Integer[expectedWidth, 20];
            var expectedAddressableIndex = (ulong)matrixArray.GetUpperBound(0);

            var matrix = new Matrix<Integer>(matrixArray);

            //Act
            var actualAddressableIndex = matrix.Width - 1;

            //Assert
            Assert.AreEqual(expectedAddressableIndex, actualAddressableIndex);
        }

        [TestMethod]
        public void Matrix_HeightMatchesUnderlyingArrayHeight_Test()
        {
            //Arrange
            const ulong expectedHeight = 10;
            var matrixArray = new Integer[77, expectedHeight];
            var matrix = new Matrix<Integer>(matrixArray);

            //Act
            var actualHeight = matrix.Height;

            //Assert
            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void Matrix_BottomEdgeIsAddressable_Test()
        {
            //Arrange
            const ulong expectedHeight = 10;
            var matrixArray = new Integer[20, expectedHeight];
            var expectedAddressableIndex = (ulong)matrixArray.GetUpperBound(1);

            var matrix = new Matrix<Integer>(matrixArray);

            //Act
            var actualAddressableIndex = matrix.Height - 1;

            //Assert
            Assert.AreEqual(expectedAddressableIndex, actualAddressableIndex);
        }

        [TestMethod]
        public void Matrix_VerticalMatrixShouldHaveWidthEqualToOne_Test()
        {
            //Arrange
            var matrix = new Matrix<Integer>(new Integer[1, 10]);

            //Act
            var actualWidth = matrix.Width;

            //Assert
            Assert.AreEqual(1ul, actualWidth);
        }

        [TestMethod]
        public void Matrix_HorizontalMatrixShouldHaveHeightEqualToOne_Test()
        {
            //Arrange
            var matrix = new Matrix<Integer>(new Integer[10, 1]);

            //Act
            var actualHeight = matrix.Height;

            //Assert
            Assert.AreEqual(1ul, actualHeight);
        }

        [TestMethod]
        public void Matrix_TopLeftCornerCanBeaddressed_Test()
        {
            //Arrange
            var expectedValue = 1;
            var matrix = new Matrix<Integer>(_array4by3);

            //Act
            var actualValue = matrix[0, 0];

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Matrix_TopRightCornerCanBeaddressed_Test()
        {
            //Arrange
            var expectedValue = 33;
            var matrix = new Matrix<Integer>(_array4by3);

            //Act
            var actualValue = matrix[matrix.Width - 1, 0];

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Matrix_BottomLeftCornerCanBeaddressed_Test()
        {
            //Arrange
            var expectedValue = 7;
            var matrix = new Matrix<Integer>(_array4by3);

            //Act
            var actualValue = matrix[0, matrix.Height - 1];

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Matrix_BottomRightCornerCanBeaddressed_Test()
        {
            //Arrange
            var expectedValue = 99;
            var matrix = new Matrix<Integer>(_array4by3);

            //Act
            var actualValue = matrix[matrix.Width - 1, matrix.Height - 1];

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion
    }
}
