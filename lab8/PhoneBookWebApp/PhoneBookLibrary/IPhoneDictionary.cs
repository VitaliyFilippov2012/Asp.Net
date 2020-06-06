using System;
using System.Collections.Generic;

namespace PhoneBookLibrary
{
    public interface IPhoneDictionary
    {
        List<PhoneBooks> GetPhoneBooks();
        PhoneBooks GetPhoneBookById(Guid id);

        void Add(string surname, string telephone);

        void Update(Guid id, string surname, string telephone);

        void Delete(Guid id);
    }
}
