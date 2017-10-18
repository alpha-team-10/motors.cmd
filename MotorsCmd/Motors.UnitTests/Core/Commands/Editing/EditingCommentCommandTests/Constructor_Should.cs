using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Editing;

namespace Motors.UnitTests.Core.Commands.Editing.EditingCommentCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            Assert.IsNotNull(new EditingCommentCommand());
        }
    }
}
