using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;

namespace Motors.Core.Commands.Deleting
{
    public class DeleteCommentCommand : ICommand
    {
        private readonly IMotorSystemContext motorSystemContext;
        private readonly ICommentInputProvider commentInputProvider;

        public DeleteCommentCommand(IMotorSystemContext context, ICommentInputProvider commentInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(commentInputProvider, "commentInputProvider").IsNull().Throw();

            this.motorSystemContext = context;
            this.commentInputProvider = commentInputProvider;
        }

        public string Execute()
        {
            var input = this.commentInputProvider.RemoveCommentInput();
            var commentToDeleteId = input[0];
            // find and delete offer with such id

            return $"Offer with {commentToDeleteId} was deleted!";
        }
    }
}
