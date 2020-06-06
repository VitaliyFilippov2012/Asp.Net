using System.Data.Entity;

namespace PhoneDictionary
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("PhoneBooks")
        { }

        public DbSet<PhoneBook> Contacts { get; set; }
    }
}
