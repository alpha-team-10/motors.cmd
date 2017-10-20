using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Deleting;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteMotorCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            // Arrange
            var contextMock = new Mock<IMotorSystemContext>();
            var providerMock = new Mock<IMotorcycleInputProvider>();

            // Act
            var command = new DeleteMotorCommand(contextMock.Object, providerMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
