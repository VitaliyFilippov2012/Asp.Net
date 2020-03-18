using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_c.Models
{
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Файл")]
        public string Path { get; private set; }

        [Display(Name = "Название")]
        public string Title { get; private set; }
        public Video()
        {
            Title = "";
            Path = "";
        }
        public Video(string path, string name)
        {
            Title = name;
            Path = path;
        }
    }
}