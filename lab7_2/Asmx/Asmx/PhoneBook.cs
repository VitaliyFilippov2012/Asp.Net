using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asmx
{
    public class PhoneBook
    {
        public PhoneBook() { }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(15)]
        public string TelephoneNumber { get; set; }

    }
}