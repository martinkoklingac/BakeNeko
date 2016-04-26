using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixDimensionsTests
    {
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
    }
}
