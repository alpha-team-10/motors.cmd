using Motors.Core;
using Motors.Data;
using Motors.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.ConsoleClient
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MotorSystemContext,Configuration>());
        }
    }
}
