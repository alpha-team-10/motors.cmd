using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands;
using Motors.Core.Providers.Contracts;
using Moq;

namespace Motors.UnitTests.Core.Commands.HelpCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenArgumentsAreValid()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();

            // Act
            var instance = new HelpCommand(writerMock.Object);

            // Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenWriterIsNull()
        {
            // AAA
            Assert.ThrowsException<ArgumentNullException>(() => new HelpCommand(null));
        }
    }
}
