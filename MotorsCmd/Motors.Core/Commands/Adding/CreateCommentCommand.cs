using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Factories.Contracts;
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
        private readonly IModelFactory factory;

        public CreateCommentCommand(IMotorSystemContext context, IModelFactory factory, 
            ICommentInputProvider commentInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(commentInputProvider, "commentInputProvider").IsNull().Throw();

            this.context = context;
            this.factory = factory;
            this.commentInputProvider = commentInputProvider;
        }
        public string Execute()
        {
            var input = this.commentInputProvider.CreateCommentInput();

            int offerId = int.Parse(input[0]);
            var content = input[1];
            var comment = this.factory.CreateComment(content);
            comment.OfferId = offerId;
            this.context.Comments.Add(comment);

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
