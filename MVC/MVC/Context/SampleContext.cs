using System.Data.Entity;
using MVC.Models;

namespace MVC.Context
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("PhoneCatalog")
        { }

        public DbSet<Contact> Contacts { get; set; }
    }
}