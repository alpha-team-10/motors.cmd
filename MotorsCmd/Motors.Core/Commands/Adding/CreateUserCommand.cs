using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers;
using Motors.Core.Providers.ConsoleInputProviders;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
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
        private readonly IMemoryCacheProvider memCache;

        public CreateUserCommand(IMotorSystemContext context, IUserInputProvider user, IModelFactory userModel,
            IMemoryCacheProvider memCache)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(user, "user").IsNull().Throw();
            Guard.WhenArgument(userModel, "userModel").IsNull().Throw();
            Guard.WhenArgument(memCache, "memCache").IsNull().Throw();

            this.context = context;
            this.user = user;
            this.userModel = userModel;
            this.memCache = memCache;
        }
        
        private string GenerateSHA256Hash(string input, string salt)
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

            var salt = Guid.NewGuid().ToString();
            string saltedPass = this.GenerateSHA256Hash(password, salt);
            
            var user = userModel.CreateUser(username, saltedPass, mail, salt);

            context.Users.Add(user);

            context.SaveChanges();
            this.memCache.MemoryCache["user"] = user;
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
