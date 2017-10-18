using Motors.ConsoleClient.Ninject;
using Motors.Core.Contracts;
using Motors.Data;
using Motors.Data.Migrations;
using Ninject;
using System.Data.Entity;

namespace Motors.ConsoleClient
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new MotorsModule());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MotorSystemContext, Configuration>());

            var engine = kernel.Get<IEngine>();
            engine.Run();
        }
        
    }
}
