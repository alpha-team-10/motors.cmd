using Motors.Core.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders
{
    public class UserInputProvider : IUserInputProvider
    {
        public IList<string> LoginUserInput()
        {
            throw new NotImplementedException();
        }

        public IList<string> RegisterUserInput()
        {
            Console.WriteLine("Enter Username");
            var username = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter Mail:");
            string mail = Console.ReadLine();

            Console.WriteLine("Enter your lucky number from 1 to 10 :)");
            string salt = Console.ReadLine();

            return new List<string> { username, password, mail, salt };
        }
    }
}
