using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Listing
{
    public class DetailsOfferCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly IOfferInputProvider offerInputProvider;

        public DetailsOfferCommand(IMotorSystemContext context, IOfferInputProvider offerInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(offerInputProvider, "offerInputProvider").IsNull().Throw();

            this.context = context;
            this.offerInputProvider = offerInputProvider;
        }

        public string Execute()
        {
            var input = this.offerInputProvider.DetailsOfferInput();
            var offerId = int.Parse(input[0]);

            var offer = this.context.Offers.Find(offerId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"#{offer.Id} {offer.Motorcycle.Model.Name} {offer.Motorcycle.Model.Manufacturer.Name}");
            sb.AppendLine($"{offer.Price}$ , offer available till: {offer.ExpireDate}");
            sb.AppendLine($"Comments: ");

            sb.AppendLine();

            return sb.ToString();
        }
    }
}
