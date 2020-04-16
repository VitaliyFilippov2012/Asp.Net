using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using lab03.Context;
using Newtonsoft.Json;

namespace lab_4.Models
{
    public class PhoneBookContext
    {
        public ContactsContext ContactsContext = new ContactsContext();
        public List<PhoneBook> PhoneBooks = new List<PhoneBook>();

        public PhoneBookContext()
        {
            FillPhoneBooks();
        }

        private void FillPhoneBooks()
        {
            PhoneBooks = ContactsContext.Contacts.ToList();
            Sort();
        }

        private void Sort()
        {
            if (PhoneBooks?.Any() == true)
                PhoneBooks = PhoneBooks.OrderBy(x => x.Surname).ToList();
        }

        public void Save()
        {
            ContactsContext.SaveChanges();
            Sort();
        }

        public void Add(string surname, string telephone)
        {
            var phoneBook = new PhoneBook() {Id = Guid.NewGuid(), Surname = surname, TelephoneNumber = telephone };
            PhoneBooks.Add(phoneBook);
            ContactsContext.Contacts.Add(phoneBook);
            Save();
            FillPhoneBooks();
        }

        public void Update(Guid id, string surname, string telephone)
        {
            var person = ContactsContext.Contacts.FirstOrDefault(x => x.Id == id);
            if(person == null)
                return;
            person.Surname = surname;
            person.TelephoneNumber = telephone;
            Save();
            FillPhoneBooks();
        }

        public void Delete(Guid id)
        {
            var person = PhoneBooks.FirstOrDefault(x => x.Id == id);
            if(person == null)
                return;
            ContactsContext.Contacts.Remove(person);
            Save();
            FillPhoneBooks();
        }
    }
}