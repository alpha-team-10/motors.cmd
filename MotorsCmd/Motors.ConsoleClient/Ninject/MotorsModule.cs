using Motors.Core;
using Motors.Core.Commands;
using Motors.Core.Commands.Adding;
using Motors.Core.Commands.Contracts;
using Motors.Core.Commands.Decorators;
using Motors.Core.Commands.Deleting;
using Motors.Core.Commands.Listing;
using Motors.Core.Commands.Other;
using Motors.Core.Contracts;
using Motors.Core.Factories;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers;
using Motors.Core.Providers.ConsoleInputProviders;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Motors.ConsoleClient.Ninject
{
    public class MotorsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMemoryCacheProvider>().To<MemoryCacheProvider>()
                .InSingletonScope();

            this.Bind<IHelperMethods>().To<HelperMethods>()
                .InSingletonScope();

            this.Bind<IDateTimeProvider>().To<DateTimeProvider>()
                .InSingletonScope();

            this.Bind<IMotorSystemContext>().To<MotorSystemContext>();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();

            this.Bind<ICommandProcessor>().To<CommandProcessor>();
            this.Bind<ICommandParser>().To<CommandParser>();

            // factories
            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IModelFactory>().To<ModelFactory>();

            //input providers
            this.Bind<IOfferInputProvider>().To<OfferInputProvider>();
            this.Bind<ICommentInputProvider>().To<CommentInputProvider>();
            this.Bind<IUserInputProvider>().To<UserInputProvider>();

            this.Bind<IMotorcycleInputProvider>().To<MotorcycleInputProvider>();


            // commands
            this.Bind<ICommand>().To<HelpCommand>().Named("help");
            this.Bind<ICommand>().To<ListOffersCommand>().Named("listoffers");
            this.Bind<ICommand>().To<DeleteOfferCommand>().Named("deleteoffer");
            this.Bind<ICommand>().To<DetailsOfferCommand>().Named("details");
            this.Bind<ICommand>().To<CurrentUserCommand>().Named("currentuser");

            this.Bind<ICommand>().To<CreateCommentCommand>().Named("comment");

            this.Bind<ICommand>().To<CreateUserCommand>().Named("register");
            this.Bind<ICommand>().To<CreateOfferCommand>().Named("InnerCreateoffer");
            this.Bind<ICommand>().To<LoginUserCommand>().Named("login");
            this.Bind<ICommand>().To<LogoutUserCommand>().Named("logout");

            this.Bind<ICommand>().To<AuthenticationCommand>()
                    .Named("createoffer")
                    .WithConstructorArgument(Kernel.Get<ICommand>("InnerCreateoffer"));


        }
    }
}
