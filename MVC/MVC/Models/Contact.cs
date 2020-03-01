using System;
using System.ComponentModel.DataAnnotations;
using MVC.Aspects;
using System.Data.Entity;

namespace MVC.Models
{
    public class Contact
    {
            [Required]
            [MaxLength(30)]
            public string Surname { get; set; }

            [Required]
            [MaxLength(30)]
            public string Firstname { get; set; }

            [Required]
            [MaxLength(30)]
            public string Middlename { get; set; }

            [Required]
            [Date]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime BDay { get; set; }

            [Key]
            [Required]
            [MaxLength(10)]
            public string Phone { get; set; }

            public Contact() { }
    }
}