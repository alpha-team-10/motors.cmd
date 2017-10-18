using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motors.Core.Commands.Editing;

namespace Motors.UnitTests.Core.Commands.Editing.EditingMotorCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnEditingMessage_WhenExecuted()
        {
            // Arrange
            var editingMotorCommand = new EditingMotorCommand();

            // Act
            string result = editingMotorCommand.Execute();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
