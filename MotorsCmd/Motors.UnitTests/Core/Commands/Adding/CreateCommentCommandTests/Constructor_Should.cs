using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Adding;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;

namespace Motors.UnitTests.Core.Commands.Adding.CreateCommentCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            // Arrange
            var contextMock = new Mock<IMotorSystemContext>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var providerMock = new Mock<ICommentInputProvider>();
            var memCacheMock = new Mock<IMemoryCacheProvider>();
            var dataTimeProvider = new Mock<IDateTimeProvider>();


            // Act
            var command = new CreateCommentCommand(contextMock.Object, modelFactoryMock.Object,
             providerMock.Object, memCacheMock.Object, dataTimeProvider.Object);

            // Assert
            Assert.IsNotNull(command);
        }
    }
}
