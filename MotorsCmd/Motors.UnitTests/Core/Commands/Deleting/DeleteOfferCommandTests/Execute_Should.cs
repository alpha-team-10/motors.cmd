using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Deleting;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteOfferCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnDeleteMessage_WhenExecuted()
        {
            // Arrange
            var deleteOfferCommand = new DeleteOfferCommand();

            // Act
            string result = deleteOfferCommand.Execute();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
