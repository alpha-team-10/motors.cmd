using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Adding;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Adding.CreateOfferCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            // Arrange
            var contextMock = new Mock<IMotorSystemContext>();
            var factoryMock = new Mock<IModelFactory>();
            var providerMock = new Mock<IOfferInputProvider>();
            var memChaseProviderMock = new Mock<IMemoryCacheProvider>();

            // Act
            var command = new CreateOfferCommand(contextMock.Object, factoryMock.Object, 
                providerMock.Object, memChaseProviderMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
