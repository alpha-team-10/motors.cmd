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
        IUser RegisterUser(string username, string password, string mail, string salt);

        IOffer CreateOffer(decimal price, string startDate, string expireDate);

        Comment CreateComment(string content);

        IMotorcycle CreateMotorCycle(int power, int category, string productionDate, decimal kms);
    }
}
