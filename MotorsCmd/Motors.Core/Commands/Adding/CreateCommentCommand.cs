using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;

namespace Motors.Core.Commands.Adding
{
    public class CreateCommentCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly ICommentInputProvider commentInputProvider;
        //private readonly SOMEMODELFACTORY factory;

        public CreateCommentCommand(IWriter writer, IMotorSystemContext context/*, SOMEMODELFACTORY factory*/, ICommentInputProvider commentInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(commentInputProvider, "commentInputProvider").IsNull().Throw();
            //Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            this.commentInputProvider = commentInputProvider;
            //this.factory = factory;
        }
        public string Execute()
        {
            var input = this.commentInputProvider.CreateCommentInput();
            //var comment = this.factory.CreateComment(input);
            //this.context.Commets.Add(comment);

            try
            {
                this.context.SaveChanges();
            }
            catch
            {
                return "Failed to save comment in the database";
            }

            return "Comment with ID" +/*{this.context.Commets.Count-1}*/ "was created.";
        }
    }
}
