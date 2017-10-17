using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;
using System;

namespace Motors.Core.Commands.Editing
{
    public class EditingOfferCommand : ICommand
    {
        private readonly IMotorSystemContext motorSystemContext;
        private readonly IOfferInputProvider offerInputProvider;

        public EditingOfferCommand(IMotorSystemContext context, IOfferInputProvider offerInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(offerInputProvider, "offerInputProvider").IsNull().Throw();

            this.motorSystemContext = context;
            this.offerInputProvider = offerInputProvider;
        }

        public string Execute()
        {
            var input = this.offerInputProvider.RemoveOfferInput();
            var offerToEditId = input[0];

            return $"Offer with ID: {offerToEditId} was edited";
        }
    }
}
