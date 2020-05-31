using System;
using System.Collections.Generic;

namespace PhoneDictionary
{
    public interface IPhoneDictionary
    {
        List<PhoneBook> GetPhoneBooks();
        void Add(string surname, string telephone);
        void Update(Guid id, string surname, string telephone);
        void Delete(Guid id);
    }
}
