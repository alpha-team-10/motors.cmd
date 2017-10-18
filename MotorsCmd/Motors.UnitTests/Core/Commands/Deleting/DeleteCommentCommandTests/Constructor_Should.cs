using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Deleting;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteCommentCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenCalled()
        {
            Assert.IsNotNull(new DeleteCommentCommand());
        }
    }
}
