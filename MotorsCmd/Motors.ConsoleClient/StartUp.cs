using Motors.ConsoleClient.Ninject;
using Motors.Core;
using Motors.Core.Contracts;
using Motors.Data;
using Motors.Data.Migrations;
using Motors.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Motors.ConsoleClient
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new MotorsModule());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MotorSystemContext, Configuration>());

            var engine = kernel.Get<IEngine>();
            ExtractFromXML();
            engine.Run();
            

        }
        private static void ExtractFromXML()
        {
            MotorSystemContext context = new MotorSystemContext();
            if (!context.Manufacturers.Any() && !context.Models.Any())
            {
                XmlDocument document = new XmlDocument();
                var appDataPath = AppDomain.CurrentDomain.GetData("/../../../").ToString();
                var filePath = Path.Combine(appDataPath, "raw-data", "data.xml");

                document.Load(filePath);
                XmlElement root = document["manufacturers"];

                foreach (XmlNode xmlManuf in root.ChildNodes)
                {
                    string manufacturerName = xmlManuf["name"].InnerText;
                    Manufacturer newManufacturer = new Manufacturer()
                    {
                        Name = manufacturerName
                    };
                    context.Manufacturers.Add(newManufacturer);
                    context.SaveChanges();
                    foreach (XmlNode xmlModel in xmlManuf["models"].ChildNodes)
                    {
                        var modelName = xmlModel.InnerText;
                        var newModel = new Model()
                        {
                            Manufacturer = context.Manufacturers
                                .Single(m => m.Name == manufacturerName),
                            Name = modelName
                        };

                        context.Models.Add(newModel);
                    }
                }

                context.SaveChanges();
            }
        }

    }
}
