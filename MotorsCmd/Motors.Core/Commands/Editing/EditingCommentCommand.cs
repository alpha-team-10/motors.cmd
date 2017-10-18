using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Editing
{
    public class EditingCommentCommand : ICommand
    {
        private readonly IMotorSystemContext motorSystemContext;
        private readonly ICommentInputProvider commentInputProvider;

        public EditingCommentCommand(IMotorSystemContext context, ICommentInputProvider commentInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(commentInputProvider, "commentInputProvider").IsNull().Throw();

            this.motorSystemContext = context;
            this.commentInputProvider = commentInputProvider;
        }

        public string Execute()
        {
            var input = this.commentInputProvider.UpdateCommentInput();
            var commentToEditId = input[0];

            return $"Offer with ID: {commentToEditId} was edited";
        }
    }
}
