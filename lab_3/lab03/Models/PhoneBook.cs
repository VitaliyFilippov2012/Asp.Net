using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab_3.Models
{
    [Serializable]
    public class PhoneBook
    {
        public Guid Id;
        public string Surname;
        public string TelephoneNumber;
    }
}