using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asmx
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("PhoneBook")
        { }
        public DbSet<PhoneBook> Books { get; set; }

    }
}