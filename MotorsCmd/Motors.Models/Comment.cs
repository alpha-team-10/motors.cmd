using System;
using System.ComponentModel.DataAnnotations;

namespace Motors.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(string content)
        {
            this.Content = content;
        }

        public int Id { get; set; }

        public int? OfferId { get; set; }

        public virtual Offer Offer { get; set; }

        public virtual User Author { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "The Comment length cannot be less than 1 or more than 250 symbols long.")]
        public string Content { get; set; }
    }
}
