using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motors.Models;
using Motors.Core.Factories.Contracts;

namespace Motors.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public Comment CreateComment(string content, DateTime date, User author, int offerId)
        {
            return new Comment()
            {
                Content = content,
                Date = date,
                Author = author,
                OfferId = offerId
            };
        }


        public Motorcycle CreateMotorcycle(Model model, int power, DateTime productionDate, decimal kilometers)
        {
            return new Motorcycle()
            {
                Model = model,
                Power = power,
                ProductionDate = productionDate,
                Kilometers = kilometers
            };
        }

        public Offer CreateOffer(User user, Motorcycle motorcycle, decimal price, DateTime startingDate, DateTime endingDate)
        {
            return new Offer
            {
                User = user,
                Motorcycle = motorcycle,
                Price = price,
                StartDate = startingDate,
                ExpireDate = endingDate
            };
        }

        public User CreateUser(string username, string password, string mail, string salt)
        {
            return new User()
            {
                Username = username,
                Password = password,
                Mail = mail,
                Salt = salt
            };
        }
    }
}