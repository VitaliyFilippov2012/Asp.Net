using System.Data.Entity;

namespace WebApi_.Models
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("PhoneBook")
        { }
        public DbSet<PhoneBook> Books { get; set; }
    }
}