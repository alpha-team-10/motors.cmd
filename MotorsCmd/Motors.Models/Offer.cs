using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Motors.Models
{
    public class Offer
    {
        public Offer()
        {
        }

        public int Id { get; set; }

        public int? MotorcycleId { get; set; }

        public virtual Motorcycle Motorcycle { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        [Range(10, 100000, ErrorMessage = "Price must be between 10 and 100000")]
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpireDate { get; set; }
        
    }
}
