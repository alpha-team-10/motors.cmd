using System.ComponentModel.DataAnnotations;

namespace Motors.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
        }

        public Manufacturer(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The Manufacturer's name length cannot be less than 2 or more than 15 symbols long.")]
        public string Name { get; set; }
    }
}
