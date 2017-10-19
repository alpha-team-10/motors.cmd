using Bytes2you.Validation;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders
{
    public class CommentInputProvider : ICommentInputProvider
    {
        private readonly IMotorcycleInputProvider motorcycleInputProvider;
        private readonly IWriter writer;
        private readonly IReader reader;

        public CommentInputProvider(IMotorcycleInputProvider motorcycleInputProvider, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(motorcycleInputProvider, "motorcycleInputProvider").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();

            this.motorcycleInputProvider = motorcycleInputProvider;
            this.writer = writer;
            this.reader = reader;
        }

        public IList<string> CreateCommentInput()
        {
            this.writer.Write("Comment on offer with ID: ");
            var offerToCommentId = this.reader.Read();

            this.writer.Write("Content: ");
            var content = this.reader.Read();


            return new List<string> {offerToCommentId, content };
        }

        public IList<string> RemoveCommentInput()
        {
            throw new NotImplementedException();
        }

        public IList<string> UpdateCommentInput()
        {
            throw new NotImplementedException();
        }
    }
}
