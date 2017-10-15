using System.ComponentModel.DataAnnotations;

namespace Motors.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "The Manufacturer's name length cannot be less than 2 or more than 15 symbols long.")]
        public string Name { get; set; }

        public override string ToString()
        {
            return "Manufacturer: " + this.Name;
        }
    }
}
