using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace PhoneDictionary
{
    public class PhoneDictionary : IPhoneDictionary
    {
        private readonly string _path;

        public PhoneDictionary()
        {
            _path = Path.GetTempPath() + @"Data.json";
        }

        public List<PhoneBook> GetPhoneBooks()
        {
            var result = new List<PhoneBook>();
            if (!File.Exists(_path))
                return result;
            using (var fs = new StreamReader(_path))
            {
                var jsonTextReader = new JsonTextReader(fs);
                var jsonSerializer = new JsonSerializer();
                result = jsonSerializer.Deserialize<List<PhoneBook>>(jsonTextReader).SortPhoneBook();
            }

            return result;
        }

        private void Save(List<PhoneBook> list)
        {
            var serializer = new JsonSerializer();
            using (JsonWriter writer = new JsonTextWriter(new StreamWriter(_path)))
            {
                serializer.Serialize(writer, list);
            }
        }

        public void Add(string surname, string telephone)
        {
            var phoneBook = new PhoneBook() { Id = Guid.NewGuid(), Surname = surname, TelephoneNumber = telephone };
            var phoneBooks = GetPhoneBooks();
            phoneBooks.Add(phoneBook);
            Save(phoneBooks);
        }

        public void Update(Guid id, string surname, string telephone)
        {
            var phoneBooks = GetPhoneBooks();
            var person = phoneBooks.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return;
            person.Surname = surname;
            person.TelephoneNumber = telephone;
            Save(phoneBooks);
        }

        public void Delete(Guid id)
        {
            var phoneBooks = GetPhoneBooks();
            var person = phoneBooks.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return;
            phoneBooks.Remove(person);

            Save(phoneBooks);
        }
    }
}
