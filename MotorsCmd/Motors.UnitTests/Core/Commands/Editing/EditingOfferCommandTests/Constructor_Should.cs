using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Editing;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Editing.EditingOfferCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            // Arrange
            var contextMock = new Mock<IMotorSystemContext>();
            var providerMock = new Mock<IOfferInputProvider>();

            // Act
            var command = new EditingOfferCommand(contextMock.Object, providerMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
