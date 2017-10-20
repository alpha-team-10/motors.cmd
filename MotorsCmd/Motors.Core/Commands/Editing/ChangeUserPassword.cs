using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Editing
{
    public class ChangeUserPassword : ICommand
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IMotorSystemContext context;
        private readonly IMemoryCacheProvider cache;
        private readonly IHelperMethods helpers;

        public ChangeUserPassword(IWriter writer, IReader reader, IMotorSystemContext context,
            IMemoryCacheProvider cache, IHelperMethods helpers)
        {
            this.writer = writer;
            this.reader = reader;
            this.context = context;
            this.cache = cache;
            this.helpers = helpers;
        }

        public string Execute()
        {
            this.writer.Write("enter new password: ");
            var newPass = this.reader.Read();

            int loggedUserId = (int)this.cache.MemoryCache["user"];

            var salt = Guid.NewGuid().ToString();
            string saltedPass = this.helpers.GenerateSHA256Hash(newPass, salt);


            var currUser = context.Users.Single(u => u.Id == loggedUserId);
            currUser.Salt = salt;
            currUser.Password = saltedPass;

            context.SaveChanges();

            return "Password changed successfully";
            
        }
    }
}
