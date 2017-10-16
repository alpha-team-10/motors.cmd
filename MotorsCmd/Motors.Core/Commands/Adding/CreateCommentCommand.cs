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
        //private readonly ICommandFactory factory;
        private readonly IWriter writer;

        public CreateCommentCommand(IMotorSystemContext context/*, ICommandFactory factory*/, IWriter writer)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            //Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.context = context;
            //this.factory = factory;
            this.writer = writer;
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
