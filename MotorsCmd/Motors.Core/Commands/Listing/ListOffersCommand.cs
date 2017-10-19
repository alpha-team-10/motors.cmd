using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Listing
{
    public class ListOffersCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IOfferInputProvider offerInputProvider;
        private readonly IMotorSystemContext context;

        public ListOffersCommand(IWriter writer, IOfferInputProvider offerInputProvider, IMotorSystemContext context)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(offerInputProvider, "userInputProvider").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.writer = writer;
            this.offerInputProvider = offerInputProvider;
            this.context = context;
        }

        public string Execute()
        {
            var input = this.offerInputProvider.ListAllOffersInput();
            ListByTypes listingType;
            Enum.TryParse(input[0], out listingType);

            string value = input[1];
            var filtered = new List<Offer>();
            switch (listingType)
            {
                case ListByTypes.Model:
                    filtered = this.context.Offers.Where(o => o.Motorcycle.Model.Name == value).ToList();
                    break;
                case ListByTypes.Manufacturer:
                    filtered = this.context.Offers.Where(o => o.Motorcycle.Model.Manufacturer.Name == value).ToList();
                    break;
                case ListByTypes.Year:
                    int year = int.Parse(value);
                    filtered = this.context.Offers.Where(o => o.Motorcycle.ProductionDate.Year == year).ToList();
                    break;
                case ListByTypes.Username:
                    filtered = this.context.Offers.Where(o => o.User.Username == value).ToList();
                    break;
                default:
                    break;
            }
            // collect or return result

            StringBuilder sb = new StringBuilder();

            foreach (var offer in filtered)
            {
                sb.AppendLine($"#{offer.Id}. {offer.Motorcycle.Model.Manufacturer.Name} {offer.Motorcycle.Model.Name}");
            }

            return sb.ToString();
        }
    }
}
