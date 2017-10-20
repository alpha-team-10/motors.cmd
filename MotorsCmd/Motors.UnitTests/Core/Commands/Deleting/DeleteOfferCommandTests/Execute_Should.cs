using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motors.Core.Commands.Deleting;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;
using Motors.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Motors.UnitTests.Core.Commands.Deleting.DeleteOfferCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void DeleteOfferWithGivenId_WhenExecuted()
        {
            // Arrange
            var mockedContext = new Mock<IMotorSystemContext>();
            var offerInputProviderMock = new Mock<IOfferInputProvider>();
            int idToDelete = 3;

            var data = new List<Offer>
            {
                    new Offer() {Id = idToDelete}
            };

            var mockSet = Helpers.GetQueryableMockDbSet(data);

            //mockedOffersDbSet.Object.Add(offerToDelete);

            mockedContext.SetupGet(c => c.Offers)
                .Returns(mockSet.Object);

            offerInputProviderMock.Setup(i => i.RemoveOfferInput())
                    .Returns(new List<string> { idToDelete.ToString() });

            var deleteOfferCommand = new DeleteOfferCommand(mockedContext.Object, offerInputProviderMock.Object);

            // Act
            string result = deleteOfferCommand.Execute();

            // Assert
            mockedContext.Verify(c => c.SaveChanges(), Times.Once);
        }

       
    }
}
