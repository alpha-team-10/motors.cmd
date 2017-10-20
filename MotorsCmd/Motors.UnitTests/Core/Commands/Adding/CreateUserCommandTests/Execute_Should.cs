using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Data;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Core.Commands.Adding;
using System.Collections.Generic;
using Motors.Models;
using System.Runtime.Caching;
using System.Data.Entity;

namespace Motors.UnitTests.Core.Commands.Adding.CreateUserCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateUserAndCallSaveChanges_WhenExecuted()
        {
            // Arrange
            var mockedContext = new Mock<IMotorSystemContext>();
            var userInputProviderMock = new Mock<IUserInputProvider>();
            var factoryMock = new Mock<IModelFactory>();
            var mockedCache = new Mock<IMemoryCacheProvider>();
            var mockedHelper = new Mock<IHelperMethods>();



            userInputProviderMock.Setup(i => i.RegisterUserInput())
                .Returns(new List<string>() { "username", "pass", "email" });

            mockedHelper.Setup(h => h.GenerateSHA256Hash(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("some-hash123");

            factoryMock.Setup(f => f.CreateUser(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new User());

            mockedContext.SetupGet(c => c.Users)
                .Returns((new Mock<IDbSet<User>>()).Object);

            var cache = new MemoryCache("test");
            cache["user"] = "2";
            mockedCache.SetupGet(c => c.MemoryCache).Returns(cache);

            

            var createUserCommand = new CreateUserCommand(mockedContext.Object,
                userInputProviderMock.Object, factoryMock.Object, mockedCache.Object,
                mockedHelper.Object);

            createUserCommand.Execute();

            mockedContext.Verify(c => c.SaveChanges(), Times.Once);

        }
    }
}
