﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Adding;

namespace Motors.UnitTests.Core.Commands.Adding.CreateCommentCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            Assert.IsNotNull(new CreateCommentCommand());
        }
    }
}