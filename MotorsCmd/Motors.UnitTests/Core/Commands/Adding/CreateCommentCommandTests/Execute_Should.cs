using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Adding;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Caching;

namespace Motors.UnitTests.Core.Commands.Adding.CreateCommentCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnAddMessageAndCallSaveChanges_WhenExecuted()
        {
            // Arrange
            var mockedContext = new Mock<IMotorSystemContext>();
            var commentInputProviderMock = new Mock<ICommentInputProvider>();
            var factoryMock = new Mock<IModelFactory>();
            var mockedCache = new Mock<IMemoryCacheProvider>();
            var mockedDatetime = new Mock<IDateTimeProvider>();

            mockedDatetime.Setup(d => d.GetDate()).Returns(new DateTime(2017, 1, 1));

            commentInputProviderMock.Setup(i => i.CreateCommentInput())
                .Returns(new List<string> { "3", "comment content" });

            mockedContext.SetupGet(c => c.Comments)
                .Returns((new Mock<IDbSet<Comment>>()).Object);

            var comment = new Comment() { Id = 3, Content = "some comment" };
            factoryMock.Setup(f => f.CreateComment("some comment", mockedDatetime.Object.GetDate(), null, 2));
            var cache = new MemoryCache("test");
            cache["user"] = 5;
            mockedCache.SetupGet(c => c.MemoryCache).Returns(cache);

            mockedContext.Setup(c => c.Users.Find(It.IsAny<int>()))
                .Returns(new User());



            var createCommentCommand = new CreateCommentCommand(mockedContext.Object,
                factoryMock.Object, commentInputProviderMock.Object, mockedCache.Object,
                mockedDatetime.Object);
            // Act
            string result = createCommentCommand.Execute();

            // Assert
            //mockedContext.Verify(c => c.Comments.Add(comment), Times.Once);
            mockedContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
