using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Factories.Contracts
{
    public interface IModelFactory
    {
        User CreateUser(string username, string password, string mail, string salt);

        Offer CreateOffer(User user, Motorcycle motorcycle, decimal price, DateTime startingDate, DateTime endingDate);

        Motorcycle CreateMotorcycle(Model model, int power, DateTime productionDate, decimal kilometers);

        Comment CreateComment(string content);
    }
}
