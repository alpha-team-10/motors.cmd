using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Models
{
    public class Motorcycle
    {
        public Motorcycle()
        {

        }

        public int Id { get; set; }

        [Required]
        [Range(1, 300, ErrorMessage = "The power should be between 1 and 300 hp!")]
        public int Power { get; set; }

        public DateTime ProductionDate { get; set; }

        [Required]
        [Range(1, 300000, ErrorMessage = "The killometers should be more than 1 and less then 300000!")]
        public decimal Kilometers { get; set; }

        public virtual Model Model { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Model.Manufacturer + " " + this.Model.Name);
            sb.AppendLine("Power: " + this.Power);           
            sb.AppendLine("Production Date: " + this.ProductionDate);
            sb.AppendLine("Kilometers: " + this.Kilometers);
            
            return sb.ToString();
        }

    }
}
