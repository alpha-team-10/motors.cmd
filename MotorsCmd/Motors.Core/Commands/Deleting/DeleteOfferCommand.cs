using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;
using Motors.Models;

namespace Motors.Core.Commands.Deleting
{
    public class DeleteOfferCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly IOfferInputProvider offerInputProvider;

        public DeleteOfferCommand(IMotorSystemContext context, IOfferInputProvider offerInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(offerInputProvider, "offerInputProvider").IsNull().Throw();

            this.context = context;
            this.offerInputProvider = offerInputProvider;
        }

        public string Execute()
        {
            var input = this.offerInputProvider.RemoveOfferInput();
            int offerId = int.Parse(input[0]);

            var offerToDelete = new Offer { Id = offerId };
            context.Offers.Attach(offerToDelete);
            context.Offers.Remove(offerToDelete);
            context.SaveChanges();

            return $"Offer with ID {offerId} was deleted!";
        }
    }
}
