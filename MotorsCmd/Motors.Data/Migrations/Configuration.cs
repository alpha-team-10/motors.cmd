using iTextSharp.text;
using iTextSharp.text.pdf;
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

            ExportToPDF(context);
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

        private static void ExportToPDF(Motors.Data.MotorSystemContext context)
        {
            FileStream fs = new FileStream("raw-data/PDF/" + "Document.pdf", FileMode.Create);

            // Create an instance of the document class which represents the PDF document itself.
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            // Create an instance to the PDF file by creating an instance of the PDF 
            // Writer class using the document and the filestrem in the constructor.
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            // Add meta information to the document
            document.AddAuthor("Team X");
            document.AddCreator("Console application using iTextSharp");
            document.AddKeywords("PDF testing");
            document.AddSubject("Document subject - Extracting things from database");
            document.AddTitle("The document title - PDF creation using iTextSharp");

            // Open the document to enable you to write to the document
            document.Open();
            // Add a simple and wellknown phrase to the document in a flow layout manner
            document.Add(new Paragraph("Team X Manufacturers and Models"));
            
            var allModels = context.Models.ToList();
            var allManufacturers = context.Manufacturers.ToList();
            
            string data = "";
        
            foreach (var manufacturer in allManufacturers)
            {
                data += manufacturer.Name + ":\n";
                
                foreach (var model in allModels)
                {
                    data += "       " + model.Name + "\n";
                }

                data += "\n";
            }

            document.Add(new Paragraph(data));
            
            // Close the document
            document.Close();
            // Close the writer instance
            writer.Close();
            // Always close open filehandles explicity
            fs.Close();
        }
    }
}
