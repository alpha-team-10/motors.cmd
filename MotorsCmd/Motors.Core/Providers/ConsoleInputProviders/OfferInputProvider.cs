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
            throw new NotImplementedException();
        }

        public IList<string> ListAllOffersInput()
        {
            throw new NotImplementedException();
        }

        public IList<string> RemoveOfferInput()
        {
            List<string> input = new List<string>();
            Console.Write("ID of offer to delete: ");
            string id = Console.ReadLine();
            input.Add(id);

            return input;
        }

        public IList<string> UpdateOfferInput()
        {
            throw new NotImplementedException();
        }
    }
}
