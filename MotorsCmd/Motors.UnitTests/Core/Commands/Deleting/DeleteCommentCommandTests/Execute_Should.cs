using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Deleting;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteCommentCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnDeleteMessage_WhenExecuted()
        {
            // Arrange
            var deleteCommentCommand = new DeleteCommentCommand();

            // Act
            string result = deleteCommentCommand.Execute();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
