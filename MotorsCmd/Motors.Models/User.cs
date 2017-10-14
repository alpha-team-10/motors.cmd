using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Models
{
    public class User
    {
        private User()
        {
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique =true)] //https://stackoverflow.com/a/23055838/4990859
        public string Username { get; set; }

        [EmailAddress]
        public string Mail { get; set; }
        
        public string Password { get; set; }

        public string Salt { get; set; }

    }
}
