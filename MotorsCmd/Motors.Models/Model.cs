using System.ComponentModel.DataAnnotations;

namespace Motors.Models
{
    public class Model
    {
        public Model()
        {
        }

        public int Id { get; set; }

        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The Model's name length cannot be less than 1 or more than 10 symbols long.")]
        public string Name { get; set; }

        //public override string ToString()
        //{
        //    return "Model: " + this.Name;
        //}
    }
}
