﻿using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;

namespace Motors.Core.Commands.Deleting
{
    public class DeleteOfferCommand : ICommand
    {
        private readonly IMotorSystemContext motorSystemContext;
        private readonly IOfferInputProvider offerInputProvider;

        public DeleteOfferCommand(IMotorSystemContext context, IOfferInputProvider offerInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(offerInputProvider, "offerInputProvider").IsNull().Throw();

            this.motorSystemContext = context;
            this.offerInputProvider = offerInputProvider;
        }

        public string Execute()
        {
            var input = this.offerInputProvider.RemoveOfferInput();
            var offerToDeleteId = input[0];
            // find and delete offer with such id

            return $"Offer with {offerToDeleteId} was deleted!";
        }
    }
}
