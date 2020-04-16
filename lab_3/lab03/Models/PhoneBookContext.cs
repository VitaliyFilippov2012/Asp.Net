using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace lab_3.Models
{
    public class PhoneBookContext
    {
        public List<PhoneBook> PhoneBooks = new List<PhoneBook>();
        readonly string _path;

        public PhoneBookContext(string path)
        {
            _path = path;
            if (!File.Exists(path))
                return;
            using (var fs = new StreamReader(path))
            {
                var jsonTextReader = new JsonTextReader(fs);
                var jsonSerializer = new JsonSerializer();
                PhoneBooks = jsonSerializer.Deserialize<List<PhoneBook>>(jsonTextReader);
                Sort();
            }
        }

        private void Sort()
        {
            if (PhoneBooks?.Any() == true)
                PhoneBooks = PhoneBooks.OrderBy(x => x.Surname).ToList();
        }

        public void Save()
        {
            var serializer = new JsonSerializer();
            using (JsonWriter writer = new JsonTextWriter(new StreamWriter(_path)))
            {
                serializer.Serialize(writer, PhoneBooks);
            }

            Sort();
        }

        public void Add(string surname, string telephone)
        {
            var phoneBook = new PhoneBook() {Id = new Guid(), Surname = surname, TelephoneNumber = telephone };
            PhoneBooks.Add(phoneBook);
            Save();
        }

        public void Update(Guid id, string surname, string telephone)
        {
            var person = PhoneBooks.FirstOrDefault(x => x.Id == id);
            if(person == null)
                return;
            person.Surname = surname;
            person.TelephoneNumber = telephone;

            Save();
        }

        public void Delete(Guid id)
        {
            var person = PhoneBooks.FirstOrDefault(x => x.Id == id);
            if(person == null)
                return;
            PhoneBooks.Remove(person);
            
            Save();
        }
    }
}