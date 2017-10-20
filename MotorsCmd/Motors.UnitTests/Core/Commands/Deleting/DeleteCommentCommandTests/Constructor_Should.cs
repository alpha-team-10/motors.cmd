using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Deleting;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteCommentCommandTests
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
            var command = new DeleteCommentCommand(contextMock.Object, providerMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
