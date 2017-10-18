using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers.ConsoleInputProviders;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Adding
{
    public class CreateUserCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly IUserInputProvider user;
        private readonly IModelFactory userModel;

        public CreateUserCommand(IMotorSystemContext context, IUserInputProvider user, IModelFactory userModel)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(user, "user").IsNull().Throw();
            Guard.WhenArgument(userModel, "userModel").IsNull().Throw();

            this.context = context;
            this.user = user;
            this.userModel = userModel;
        }

        public string CreateSalt(string size)
        {
            var range = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[int.Parse(size)];
            range.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring =
                new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public string Execute()
        {
            var userInput = this.user.RegisterUserInput();

            var username = userInput[0];
            var password = userInput[1];
            var mail = userInput[2];
            var salt = userInput[3];

            var saltedPass = CreateSalt(salt);
            string hashedPass = GenerateSHA256Hash(password, saltedPass);
            password = hashedPass;


            var user = userModel.CreateUser(username, password, mail, salt);

            context.Users.Add(user);
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            

            return $"User with username {username} was created!";
        }
    }
}
