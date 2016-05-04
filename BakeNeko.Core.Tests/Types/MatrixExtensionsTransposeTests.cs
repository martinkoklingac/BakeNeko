using BakeNeko.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeNeko.Core.Tests.Types
{
    [TestClass]
    public class MatrixExtensionsTransposeTests
    {
        #region TESTS
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
        #endregion
    }
}
