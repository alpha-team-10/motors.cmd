using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Deleting;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteMotorCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnDeleteMessage_WhenExecuted()
        {
            // Arrange
            var deleteMotorCommand = new DeleteMotorCommand();

            // Act
            string result = deleteMotorCommand.Execute();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
