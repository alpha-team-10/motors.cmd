using Motors.Core.Contracts;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Factories
{
    public interface IMobileFactory
    {
        User CreateUser(string username, string password, string mail, string salt);

        Offer CreateOffer(decimal price, string startDate, string expireDate);

        Comment CreateComment(string content);

        Motorcycle CreateMotorCycle(int power, int category, string productionDate, decimal kms);
    }
}
