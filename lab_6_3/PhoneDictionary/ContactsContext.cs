using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("PhoneBooks")
        { }

        public DbSet<PhoneBook> Contacts { get; set; }
    }
}
