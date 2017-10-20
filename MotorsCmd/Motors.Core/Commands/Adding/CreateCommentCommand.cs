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
        private readonly IMemoryCacheProvider cache;
        private readonly IDateTimeProvider datetimeProvider;

        public CreateCommentCommand(IMotorSystemContext context, IModelFactory factory,
            ICommentInputProvider commentInputProvider, IMemoryCacheProvider cache, IDateTimeProvider datetimeProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(commentInputProvider, "commentInputProvider").IsNull().Throw();
            Guard.WhenArgument(cache, "cache").IsNull().Throw();
            Guard.WhenArgument(datetimeProvider, "datetimeProvider").IsNull().Throw();

            this.context = context;
            this.factory = factory;
            this.commentInputProvider = commentInputProvider;
            this.cache = cache;
            this.datetimeProvider = datetimeProvider;
        }
        public string Execute()
        {
            var input = this.commentInputProvider.CreateCommentInput();

            int userId = (int)this.cache.MemoryCache["user"];
            var author = this.context.Users.Find(userId);
            var currentDate = this.datetimeProvider.GetDate();

            int offerId = int.Parse(input[0]);
            var content = input[1];
            var comment = this.factory.CreateComment(content, currentDate, author, offerId);
            this.context.Comments.Add(comment);

            this.context.SaveChanges();


            return "Comment with ID" +/*{this.context.Commets.Count-1}*/ "was created.";
        }
    }
}
