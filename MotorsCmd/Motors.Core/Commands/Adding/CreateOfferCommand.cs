using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Factories.Contracts;
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
        private readonly IModelFactory factory;
        private readonly IMemoryCacheProvider memCache;

        public CreateOfferCommand(IMotorSystemContext context, IModelFactory factory, IOfferInputProvider offerInputProvider
            , IMemoryCacheProvider memCache)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(offerInputProvider, "offerInputProvider").IsNull().Throw();
            Guard.WhenArgument(memCache, "memCache").IsNull().Throw();

            this.context = context;
            this.factory = factory;
            this.offerInputProvider = offerInputProvider;
            this.memCache = memCache;

        }

        public string Execute()
        {
            var offerInput = this.offerInputProvider.CreateOfferInput();
            
            int modelId = int.Parse(offerInput[0]);
            DateTime productionDate = new DateTime(int.Parse(offerInput[1]),1,1);
            int power = int.Parse(offerInput[2]);
            decimal kms = decimal.Parse(offerInput[3]);
            decimal price = decimal.Parse(offerInput[4]);


            var model = context.Models.Single(m => m.Id == modelId);
            
            var motor = this.factory.CreateMotorcycle(model,power,productionDate,kms);
            int loggedUserId = int.Parse(this.memCache.MemoryCache["user"].ToString());

            var user = this.context.Users.Single(u => u.Id == loggedUserId);
            
            var offer = this.factory.CreateOffer(user,motor,price,DateTime.Now,DateTime.Now.AddDays(30));

            context.Offers.Add(offer);
            context.SaveChanges();
            
            // TODO: Dispose, DateTime Provider, Tests
            return $"Offer with ID { offer.Id} was created by USER {user.Username}.";
        }
    }
}
