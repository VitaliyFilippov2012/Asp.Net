using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_c.Models
{
    public class SampleContext : DbContext
    {

        public SampleContext() : base("VideoCatalog")
        { }

        public DbSet<Video> Videos { get; set; }
    }
}