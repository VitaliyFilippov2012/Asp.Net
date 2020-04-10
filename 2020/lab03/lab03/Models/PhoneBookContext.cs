using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using lab03.Controllers;
using Newtonsoft.Json;

namespace lab03.Models
{
    public class PhoneBookContext
    {
        public List<PhoneBook> phoneBooks = new List<PhoneBook>();
        string Path;
        public PhoneBookContext(string path)
        {
            Path = path;
            if (!File.Exists(path))
                return;
            using (var fs = new StreamReader(path))
            {
                var jsonTextReader = new JsonTextReader(fs);
                var jsonSerializer = new JsonSerializer();
                phoneBooks = jsonSerializer.Deserialize<List<PhoneBook>>(jsonTextReader);
            }
        }
        public void Save()
        {
            var serializer = new JsonSerializer();
            using (JsonWriter writer = new JsonTextWriter(new StreamWriter(Path)))
            {
                serializer.Serialize(writer, phoneBooks);
            }
        }
        public void Add(string surname, string telephone)
        {
            var phoneBook = new PhoneBook() {Id = phoneBooks.Count + 1, Surname = surname, TelephoneNumber = telephone };
            phoneBooks.Add(phoneBook);
            Save();
        }
        public void Update(int id, string surname, string telephone)
        {
            foreach (var t in phoneBooks)
            {
                if (t.Id != id)
                    continue;
                t.Surname = surname;
                t.TelephoneNumber = telephone;
                break;
            }

            Save();
        }
        public void Delete(int id)
        {
            for (var item = 0; item < phoneBooks.Count; item++)
            {
                if (phoneBooks[item].Id != id) 
                    continue;
                phoneBooks.RemoveAt(item);
                break;
            }
            Save();
        }
    }
}