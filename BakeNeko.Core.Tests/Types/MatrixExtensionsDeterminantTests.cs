using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixExtensionsDeterminantTests
    {
        #region PRIVATE FIELDS
        /*  
            ┌─────┬────┐
            |  67 | -1 |
            ├─────┼────┤
            |-153 | 89 |
            └─────┴────┘
        */
        private static Matrix<Integer> _square2x2Matrix;
        #endregion

        #region SETUP / TEARDOWN
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _square2x2Matrix = new Matrix<Integer>(new Integer[2, 2]
            {
                {67, -153 },
                {-1, 89 }
            });
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _square2x2Matrix = null;
        }
        #endregion

        #region TESTS
        /// <summary>
        /// |A| = |A^t|
        /// </summary>
        [TestMethod]
        public void MatrixExtensions_Determinant_DetA_Equals_DetATransposed_Test()
        {
            //Arrange
            var mTranspose = _square2x2Matrix.Transpose();

            //Act
            var detM = _square2x2Matrix.Determinant();
            var detMt = mTranspose.Determinant();

            //Assert
            Assert.AreEqual(detM, detMt);
        }

        /// <summary>
        /// c^n|A| = |cA|
        /// </summary>
        [TestMethod]
        public void MatrixExtensions_Determinant_CToNthPower_TimesDetA_Equals_DetATimesC_Test()
        {
            //Arrange
            var constant = 7;
            var constantSquared = constant * constant;
            var constantA = constant * _square2x2Matrix;

            //Act
            var detA = _square2x2Matrix.Determinant();          //|A|
            var constantSquaredDetA = constantSquared * detA;   //c^2|A|
            var detConstantA = constantA.Determinant();         //|cA|

            //Assert
            Assert.AreEqual(constantSquaredDetA, detConstantA);
        }
        #endregion
    }
}
