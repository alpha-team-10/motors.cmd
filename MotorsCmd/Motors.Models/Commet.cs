using System.ComponentModel.DataAnnotations;

namespace Motors.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        public int Id { get; set; }

        public int? OfferId { get; set; }

        public virtual Offer Offer { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "The Comment length cannot be less than 10 or more than 250 symbols long.")]
        public string Content { get; set; }

        public override string ToString()
        {
            return this.Content;
        }
    }
}
