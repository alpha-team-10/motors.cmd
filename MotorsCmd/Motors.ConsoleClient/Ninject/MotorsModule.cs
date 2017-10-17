﻿using Motors.Core;
using Motors.Core.Commands;
using Motors.Core.Commands.Contracts;
using Motors.Core.Commands.Deleting;
using Motors.Core.Commands.Listing;
using Motors.Core.Contracts;
using Motors.Core.Factories;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers;
using Motors.Core.Providers.ConsoleInputProviders;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.ConsoleClient.Ninject
{
    public class MotorsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMotorSystemContext>().To<MotorSystemContext>();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();

            this.Bind<ICommandProcessor>().To<CommandProcessor>();
            this.Bind<ICommandParser>().To<CommandParser>();

            this.Bind<ICommandFactory>().To<CommandFactory>();

            this.Bind<IOfferInputProvider>().To<OfferInputProvider>();

            this.Bind<ICommand>().To<HelpCommand>().Named("help");
            this.Bind<ICommand>().To<ListOffersCommand>().Named("listoffers");
            this.Bind<ICommand>().To<DeleteOfferCommand>().Named("deleteoffer");


        }
    }
}
