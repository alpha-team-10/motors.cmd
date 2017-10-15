using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;

namespace Motors.Core.Commands.Adding
{
    public class CreateCommentCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        //private readonly ICommandFactory factory;

        public CreateCommentCommand(IMotorSystemContext context/*, ICommandFactory factory*/)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            //Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            //this.factory = factory;
        }
        public void Execute(IList<string> parameters)
        {
            string content;

            try
            {
                content = parameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateComment command parameters.");
            }

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

            Console.WriteLine("Comment with ID" +/*{this.context.Commets.Count-1}*/ "was created.");
        }
    }
}
