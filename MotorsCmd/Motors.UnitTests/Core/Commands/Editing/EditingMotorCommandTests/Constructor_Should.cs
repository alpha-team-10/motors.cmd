using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Editing;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Editing.EditingMotorCommandTests
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
            var command = new EditingMotorCommand(contextMock.Object, providerMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
