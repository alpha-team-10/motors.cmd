using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Adding;

namespace Motors.UnitTests.Core.Commands.Adding.CreateCommentCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnAddMessage_WhenExecuted()
        {
            // Arrange
            var createCommentCommand = new CreateCommentCommand();

            // Act
            string result = createCommentCommand.Execute();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
