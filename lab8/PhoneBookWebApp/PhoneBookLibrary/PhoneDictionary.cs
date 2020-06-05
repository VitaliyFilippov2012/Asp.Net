using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookLibrary
{
    public class PhoneDictionary : IPhoneDictionary
    {
        private readonly IContactsContext _contactsContext;

        public PhoneDictionary(IContactsContext contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public List<PhoneBooks> GetPhoneBooks()
        {
            return _contactsContext.PhoneBooks.OrderBy(x => x.Surname).ToList();
        }

        public PhoneBooks GetPhoneBookById(Guid id)
        {
            return _contactsContext.PhoneBooks.FirstOrDefault(x => x.Id == id);
        }

        public void Add(string surname, string telephone)
        {
            var phoneBook = new PhoneBooks() { Id = Guid.NewGuid(), Surname = surname, TelephoneNumber = telephone };
            _contactsContext.PhoneBooks.Add(phoneBook);
            _contactsContext.SaveDbChangesAsync();
        }

        public void Update(Guid id, string surname, string telephone)
        {
            var person = _contactsContext.PhoneBooks.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return;
            person.Surname = surname;
            person.TelephoneNumber = telephone;
            _contactsContext.PhoneBooks.Update(person);
            _contactsContext.SaveDbChangesAsync();
        }

        public void Delete(Guid id)
        {
            var person = GetPhoneBookById(id);
            if (person == null)
                return;
            _contactsContext.PhoneBooks.Remove(person);
            _contactsContext.SaveDbChangesAsync();
        }
    }
}
