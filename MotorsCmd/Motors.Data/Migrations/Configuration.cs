using Motors.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Xml;

namespace Motors.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Motors.Data.MotorSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Motors.Data.MotorSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //ExtractFromJSON();
            ExtractFromXML();

        }

        private static void ExtractFromXML()
        {
            MotorSystemContext context = new MotorSystemContext();
            if (!context.Manufacturers.Any() && !context.Models.Any())
            {
                XmlDocument document = new XmlDocument();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../raw-data", "data.xml");

                document.Load(filePath);
                XmlElement root = document["manufacturers"];

                foreach (XmlNode xmlManuf in root.ChildNodes)
                {
                    string manufacturerName = xmlManuf["name"].InnerText;
                    Manufacturer newManufacturer = new Manufacturer()
                    {
                        Name = manufacturerName
                    };
                    foreach (XmlNode xmlModel in xmlManuf["models"].ChildNodes)
                    {
                        var modelName = xmlModel.InnerText;
                        var newModel = new Model()
                        {
                            Manufacturer = newManufacturer,
                            Name = modelName
                        };

                        context.Models.Add(newModel);
                    }
                }

                context.SaveChanges();
                Console.WriteLine("models and manufacturers populated with XML");
            }
        }
    }
}
