using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixMultiplicationTests
    {
        #region PRIVATE FIELDS
        /*  
            ┌───┬───┐
            | 0 | 0 |
            ├───┼───┤
            | 0 | 0 |
            └───┴───┘
        */
        private static Integer[,] _squareZeroArray;
        
        /*  
            ┌───┬───┐
            | 1 | 1 |
            ├───┼───┤
            | 1 | 1 |
            └───┴───┘
        */
        private static Integer[,] _squareUnityArray;
        #endregion

        #region SETUP / TEARDOWN
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _squareZeroArray = new Integer[2, 2]
            {
                {0, 0 },
                {0, 0 }
            };

            _squareUnityArray = new Integer[2, 2]
            {
                {1,1 },
                {1,1 }
            };
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _squareZeroArray = null;
            _squareUnityArray = null;
        }
        #endregion

        #region TESTS
        [TestMethod]
        public void Matrix_Multiplication_Square_ZeroTimesZeroIsZero_Test()
        {
            //Arrange
            var expectedMatrix = new Matrix<Integer>(_squareZeroArray);
            var m1 = new Matrix<Integer>(_squareZeroArray);
            var m2 = new Matrix<Integer>(_squareZeroArray);

            //Act
            var result = m1 * m2;

            //Assert
            Assert.AreEqual(expectedMatrix, result);
        }

        [TestMethod]
        public void Matrix_Multiplication_Square_ZeroTimesUnityIsZero_Test()
        {
            //Arrange
            var expectedMatrix = new Matrix<Integer>(_squareZeroArray);
            var m1 = new Matrix<Integer>(_squareZeroArray);
            var m2 = new Matrix<Integer>(_squareUnityArray);

            //Act
            var result = m1 * m2;

            //Assert
            Assert.AreEqual(expectedMatrix, result);
        }

        [TestMethod]
        public void Matrix_Multiplication_Square_UnityTimesZeroIsZero_Test()
        {
            //Arrange
            var expectedMatrix = new Matrix<Integer>(_squareZeroArray);
            var m1 = new Matrix<Integer>(_squareUnityArray);
            var m2 = new Matrix<Integer>(_squareZeroArray);

            //Act
            var result = m1 * m2;

            //Assert
            Assert.AreEqual(expectedMatrix, result);
        }

        [TestMethod]
        public void Matrix_Multiplication_Square_UnityTimesUnityIsSquareOf2s_Test()
        {
            //Arrange
            var expectedMatrix = new Matrix<Integer>(new Integer[2, 2] { { 2, 2 }, { 2, 2 } });
            var m1 = new Matrix<Integer>(_squareUnityArray);
            var m2 = new Matrix<Integer>(_squareUnityArray);

            //Act
            var result = m1 * m2;

            //Assert
            Assert.AreEqual(expectedMatrix, result);
        }

        [TestMethod]
        public void Matrix_Multiplication_ConformableHorizontalTimesVertical_Test()
        {
            //Arrange
            var expectedMatrix = new Matrix<Integer>(new Integer[,] { { 50 } });
            var m1 = new Matrix<Integer>(new Integer[,] { { 1 }, { 2 }, { 3 } });
            var m2 = new Matrix<Integer>(new Integer[,] { { 7, 8, 9 } });

            //Act
            var result = m1 * m2;

            //Assert
            Assert.AreEqual(expectedMatrix, result);
        }

        [TestMethod]
        public void Matrix_Multiplication_ConformableRectangular_Test()
        {
            //Arrange
            /*  
                ┌─────┬────┐
                |  67 | -1 |
                ├─────┼────┤
                |-153 | 89 |
                └─────┴────┘
            */
            var expectedMatrix = new Matrix<Integer>(new Integer[2, 2]
            {
                { 67, -153 },
                { -1, 89 }
            });

            /*  
                ┌────┬────┐────┐
                |  1 |  2 |  3 |
                ├────┼────┤────┤
                |  8 | -7 |-11 |
                └────┴────┘────┘
            */
            var m1 = new Matrix<Integer>(new Integer[3, 2]
            {
                { 1, 8 },
                { 2, -7 },
                { 3, -11 }
            });

            /*  
                ┌────┬────┐
                |  7 |  7 |
                ├────┼────┤
                | 33 | 11 |
                ├────┼────┤
                | -2 |-10 |
                └────┴────┘
            */
            var m2 = new Matrix<Integer>(new Integer[2, 3]
            {
                { 7, 33, -2 },
                { 7, 11, -10 }
            });

            //Act
            var result = m1 * m2;

            //Assert
            Assert.AreEqual(expectedMatrix, result);
        }
        #endregion
    }
}
