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
        public void ReturnInstance_WhenCalled()
        {
            Assert.IsNotNull(new HelpCommand());
        }
    }
}
