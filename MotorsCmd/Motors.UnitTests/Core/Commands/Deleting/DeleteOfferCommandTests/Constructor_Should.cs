using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Deleting;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteOfferCommandTests
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
            var command = new DeleteOfferCommand(contextMock.Object, providerMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
