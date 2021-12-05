using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20),MinLength(3)]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
