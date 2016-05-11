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

        /*  
            ┌─────┬────┬────┐
            |  67 | -1 | -7 |
            ├─────┼────┼────┤
            |-153 | 89 | -2 |
            ├─────┼────┼────┤
            |  23 |  0 | 32 |
            └─────┴────┴────┘
        */
        private static Matrix<Integer> _square3x3Matrix;
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

            _square3x3Matrix = new Matrix<Integer>(new Integer[3, 3]
            {
                {67, -153, 23 },
                {-1, 89, 0 },
                {-7, -2, 32 }
            });
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _square2x2Matrix = null;
            _square3x3Matrix = null;
        }
        #endregion

        #region TESTS
        [TestMethod]
        public void MatrixExtensions_Determinant_DetI_Equals1_2x2_Test()
        {
            //Arrange
            var mIdentity = MatrixExtensions.Identity<Integer>(2);

            //Act
            var determinant = mIdentity.Determinant();

            //Assert
            Assert.AreEqual(Integer.Identity(), determinant);
        }

        [TestMethod]
        public void MatrixExtensions_Determinant_DetI_Equals1_3x3_Test()
        {
            //Arrange
            var mIdentity = MatrixExtensions.Identity<Integer>(3);

            //Act
            var determinant = mIdentity.Determinant();

            //Assert
            Assert.AreEqual(Integer.Identity(), determinant);
        }

        /// <summary>
        /// |A| = |A^t|
        /// </summary>
        [TestMethod]
        public void MatrixExtensions_Determinant_DetA_Equals_DetATransposed_2x2_Test()
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
        /// |A| = |A^t|
        /// </summary>
        [TestMethod]
        public void MatrixExtensions_Determinant_DetA_Equals_DetATransposed_3x3_Test()
        {
            //Arrange
            var mTranspose = _square3x3Matrix.Transpose();

            //Act
            var detM = _square3x3Matrix.Determinant();
            var detMt = mTranspose.Determinant();

            //Assert
            Assert.AreEqual(detM, detMt);
        }

        /// <summary>
        /// c^n|A| = |cA|
        /// </summary>
        [TestMethod]
        public void MatrixExtensions_Determinant_CToNthPower_TimesDetA_Equals_DetATimesC_2x2_Test()
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

        /// <summary>
        /// c^n|A| = |cA|
        /// </summary>
        [TestMethod]
        public void MatrixExtensions_Determinant_CToNthPower_TimesDetA_Equals_DetATimesC_3x3_Test()
        {
            //Arrange
            var constant = 7;
            var constantSquared = constant * constant * constant;
            var constantA = constant * _square3x3Matrix;

            //Act
            var detA = _square3x3Matrix.Determinant();          //|A|
            var constantSquaredDetA = constantSquared * detA;   //c^2|A|
            var detConstantA = constantA.Determinant();         //|cA|

            //Assert
            Assert.AreEqual(constantSquaredDetA, detConstantA);
        }
        #endregion
    }
}
