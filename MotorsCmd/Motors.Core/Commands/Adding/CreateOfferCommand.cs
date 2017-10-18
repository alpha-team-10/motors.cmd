﻿using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motors.Core.Commands.Adding
{
    public class CreateOfferCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly IOfferInputProvider offerInputProvider;
        //private readonly IMODELFACTORY factory;

        public CreateOfferCommand(IMotorSystemContext context/*, IMODELFACTORY factory*/, IOfferInputProvider offerInputProvider,
            IMotorcycleInputProvider motorocycleInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            //Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(offerInputProvider, "offerInputProvider").IsNull().Throw();
            Guard.WhenArgument(motorocycleInputProvider, "motorocycleInputProvider").IsNull().Throw();

            this.context = context;
            //this.factory = factory;
            this.offerInputProvider = offerInputProvider;

        }

        public string Execute()
        {
            var offerInput = this.offerInputProvider.CreateOfferInput();

            // var motor = this.factory.CreateMotor(input);
            // var offer = this.factory.CreateOffer(input);
            
            int modelId = int.Parse(offerInput[0]);
            DateTime productionDate = new DateTime(int.Parse(offerInput[1]),1,1);
            int power = int.Parse(offerInput[2]);
            decimal kms = decimal.Parse(offerInput[3]);
            decimal price = decimal.Parse(offerInput[4]);


            var model = context.Models.Single(m => m.Id == modelId);

            var motorcycle = new Motorcycle()
            {
                Kilometers = kms,
                Model = model,
                Power = power,
                ProductionDate = productionDate
            };

            // test user
            var user = new User()
            {
                Mail = "asd1@abv.bg",
                Password = "1234565",
                Salt = "asfjas;lfjagjas",
                Username = "user1"
            };

            var offer = new Offer()
            {
                StartDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddDays(30),
                Motorcycle = motorcycle,
                Price = price,
                User = user
            };

            context.Offers.Add(offer);
            context.SaveChanges();
            
            return $"Offer with ID { offer.Id} was created.";
        }
    }
}
