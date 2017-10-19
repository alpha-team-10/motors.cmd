using Bytes2you.Validation;
using Motors.Core.Commands.Listing;
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
    public class OfferInputProvider : IOfferInputProvider
    {
        private readonly IMotorcycleInputProvider motorcycleInputProvider;
        private readonly IWriter writer;
        private readonly IReader reader;

        public OfferInputProvider(IMotorcycleInputProvider motorcycleInputProvider, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(motorcycleInputProvider, "motorcycleInputProvider").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();

            this.motorcycleInputProvider = motorcycleInputProvider;
            this.writer = writer;
            this.reader = reader;
        }

        public IList<string> CreateOfferInput()
        {
            var input = new List<string>();
            var motorcycleInput = motorcycleInputProvider.CreateMotorcycleInput();
            input.AddRange(motorcycleInput);

            this.writer.Write("Price: ");
            var offerPrice = this.reader.Read();

            input.Add(offerPrice);

            return input;
        }

        public IList<string> DetailsOfferInput()
        {
            this.writer.Write("Enter offer ID: ");
            var offerId = this.reader.Read();

            return new List<string> { offerId };
        }

        public IList<string> ListAllOffersInput()
        {
            // concrete username, by model, manufacturers

            this.writer.Write("List by:");
            foreach (ListByTypes item in Enum.GetValues(typeof(ListByTypes)))
            {
                this.writer.Write($"({(int)item}) {item}");
            }
            var choice = int.Parse(this.reader.Read());
            string value = ((int)ListByTypes.None).ToString();
            if ((ListByTypes)choice != ListByTypes.None)
            {
                this.writer.Write("Enter value: ");
                value = this.reader.Read();
            }


            return new List<string> { ((ListByTypes)choice).ToString(), value };
        }

        public IList<string> RemoveOfferInput()
        {
            this.writer.Write("ID of offer to delete: ");
            string offerId = this.reader.Read();

            return new List<string> { offerId };
        }

        public IList<string> UpdateOfferInput()
        {
            throw new NotImplementedException();
        }
    }
}
