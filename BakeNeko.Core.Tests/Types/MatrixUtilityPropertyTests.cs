using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixUtilityPropertyTests
    {
        #region PRIVATE FIELDS
        /*  
            ┌───┐
            | 1 |
            └───┘
        */
        private static Integer[,] _array1by1;

        /*  
            ┌───┬───┐────┐
            | 1 | 2 | 33 |
            ├───┼───┤────┤
            | 4 | 5 | 66 |
            ├───┼───┤────┤
            | 7 | 8 | 99 |
            └───┴───┘────┘
        */
        private static Integer[,] _array3by3;

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

        /*  
            ┌────┬────┐────┐
            | 1  | 2  | 3  |
            ├────┼────┤────┤
            | 4  | 5  | 6  |
            ├────┼────┤────┤
            | 7  | 8  | 9  |
            ├────┼────┤────┤
            | 77 | 88 | 99 |
            └────┴────┘────┘
        */
        private static Integer[,] _array3by4;
        #endregion

        #region SETUP / TEARDOWN
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _array1by1 = new Integer[1, 1] { { 1 } };
            _array3by3 = new Integer[3, 3]
            {
                {1, 4, 7},
                {2, 5, 8 },
                {33, 66, 99 }
            };
            _array4by3 = new Integer[4, 3]
            {
                {1, 4, 7 },
                {2, 5, 8 },
                {3, 6, 9 },
                {33, 66, 99 }
            };

            _array3by4 = new Integer[3, 4]
            {
                {1, 4, 7, 77 },
                {2, 5, 8, 88 },
                {3, 6, 9, 99 }
            };
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _array1by1 = null;
            _array3by3 = null;
            _array4by3 = null;
            _array3by4 = null;
        }
        #endregion

        #region TESTS
        [TestMethod]
        public void Matrix_IsSquare_DegenerateOnebyOne_Test()
        {
            //Arrange
            var matrix = new Matrix<Integer>(_array1by1);

            //Assert
            Assert.IsTrue(matrix.IsSquare);
        }

        [TestMethod]
        public void Matrix_IsSquare_NonTrivial3by3_Test()
        {
            //Arrange
            var matrix = new Matrix<Integer>(_array3by3);

            //Assert
            Assert.IsTrue(matrix.IsSquare);
        }

        [TestMethod]
        public void Matrix_IsSquare_WidthIsGreaterThenHeight_Test()
        {
            //Arrange
            var matrix = new Matrix<Integer>(_array4by3);

            //Assert
            Assert.IsFalse(matrix.IsSquare);
        }

        [TestMethod]
        public void Matrix_IsSquare_HeightIsGreaterThenWidth_Test()
        {
            //Arrange
            var matrix = new Matrix<Integer>(_array3by4);

            //Assert
            Assert.IsFalse(matrix.IsSquare);
        }
        #endregion
    }
}
