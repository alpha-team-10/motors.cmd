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
        public void ReturnHelpMessage_WhenExecuted()
        {
            // Arrange
            var helpCommand = new HelpCommand();

            // Act
            string result = helpCommand.Execute();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
