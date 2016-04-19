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
            var actualIdentityMatrix = 1.Indentity(1);

            //Act
            var expectedValue = actualIdentityMatrix[0, 0];

            //Assert
            Assert.AreEqual(1ul, actualIdentityMatrix.Width);
            Assert.AreEqual(1ul, actualIdentityMatrix.Height);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
