using Bytes2you.Validation;
using Motors.Core.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
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

        private readonly IWriter writer;
        private readonly IReader reader;

        public UserInputProvider(IWriter writer, IReader reader)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();

            this.writer = writer;
            this.reader = reader;
        }

        public IList<string> LoginUserInput()
        {
            this.writer.Write("Enter Username");
            var username = this.reader.Read();


            this.writer.Write("Enter Password");
            var password = this.reader.Read();

            return new List<string> { username, password };
        }

        public IList<string> LogoutUserInput()
        {
            this.writer.Write("Are you  sure you want to logout ? (y\\n)");
            var response = this.reader.Read();

            return new List<string> { response };
        }

        public IList<string> RegisterUserInput()
        {
            Console.WriteLine("Enter Username");
            var username = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter Mail:");
            string mail = Console.ReadLine();

            return new List<string> { username, password, mail };
        }

        
    }
}
