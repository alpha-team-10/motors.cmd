using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;

namespace Motors.Core.Commands.Adding
{
    public class CreateCommentCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        //private readonly SOMEMODELFACTORY factory;

        public CreateCommentCommand(IMotorSystemContext context/*, SOMEMODELFACTORY factory*/)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            //Guard.WhenArgument(factory, "factory").IsNull().Throw();
            
            this.context = context;
            //this.factory = factory;
        }
        public string Execute()
        {
            //var comment = this.factory.CreateComment(content);
            //this.context.Commets.Add(comment);

            try
            {
                this.context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Failed to save comment in the database");
            }

            return "Comment with ID" +/*{this.context.Commets.Count-1}*/ "was created.";
        }
    }
}
