using Microsoft.VisualStudio.TestTools.UnitTesting;
using BakeNeko.Core.Types;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixExtensionsIdentityTests
    {
        [TestMethod]
        public void MatrixExtensions_Identity_OneByOneIdentity_Test()
        {
            //Arrange
            const int actualValue = 1;
            var identityMatrixArray = new int[1, 1] { { actualValue } };
            var actualIdentityMatrix = MatrixExtensions.Indentity<Integer>(1);

            //Act
            var expectedValue = actualIdentityMatrix[0, 0];

            //Assert
            Assert.AreEqual(1ul, actualIdentityMatrix.Width);
            Assert.AreEqual(1ul, actualIdentityMatrix.Height);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void MatrixExtensions_Identity_NByNIdentity_Test()
        {
            //Arrange
            const int actualValue = 1;
            var identityMatrixArray = new Integer[3, 3]
            {
                {actualValue, 0, 0 },
                {0, actualValue, 0 },
                {0, 0, actualValue }
            };

            var actualIdentityMatrix = MatrixExtensions.Indentity<Integer>(3);

            //Assert
            Assert.AreEqual(3ul, actualIdentityMatrix.Width);
            Assert.AreEqual(3ul, actualIdentityMatrix.Height);

            for (var height = 0ul; height < actualIdentityMatrix.Height; height++)
                for (var width = 0ul; width < actualIdentityMatrix.Width; width++)
                    Assert.AreEqual(identityMatrixArray[width, height], actualIdentityMatrix[width, height]);
        }
    }
}
