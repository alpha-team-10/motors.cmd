using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands;
using Moq;
using Motors.Core.Providers.Contracts;

namespace Motors.UnitTests.Core.Commands.HelpCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CallWriteMethod_WhenExecuteIsCalled()
        {
            // Arrange
            var mockedWriter = new Mock<IWriter>();
            var helpCommand = new HelpCommand(mockedWriter.Object);

            // Act
            helpCommand.Execute();

            // Assert
            mockedWriter.Verify(w => w.Write(It.IsAny<string>()), Times.Once);
        }
    }
}
