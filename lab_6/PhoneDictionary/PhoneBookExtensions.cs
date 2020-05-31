using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary
{
    public static class PhoneBookExtensions
    {
        public static List<PhoneBook> SortPhoneBook(this List<PhoneBook> list)
        {
            return list?.OrderBy(x => x.Surname).ToList();
        }
    }
}
