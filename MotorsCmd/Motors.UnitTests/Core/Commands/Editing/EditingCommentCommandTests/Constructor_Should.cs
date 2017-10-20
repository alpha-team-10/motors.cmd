using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Editing;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Editing.EditingCommentCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            // Arrange
            var contextMock = new Mock<IMotorSystemContext>();
            var providerMock = new Mock<ICommentInputProvider>();


            // Act
            var command = new EditingCommentCommand(contextMock.Object, providerMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
