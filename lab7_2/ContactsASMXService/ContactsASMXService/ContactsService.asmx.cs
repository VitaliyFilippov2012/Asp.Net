using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Services;
using PhoneDictionary;

namespace ContactsASMXService
{
    /// <summary>
    /// Summary description for ContactsService
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ContactsService : System.Web.Services.WebService
    {

        private readonly ContactsContext _phoneBookContext;

        public ContactsService()
        {
            _phoneBookContext = new ContactsContext();
        }

        [WebMethod]
        public List<PhoneBook> GetDict()
        {
            var с = _phoneBookContext.Contacts.ToList();
            return с;
        }

        [WebMethod]
        public bool AddDict(PhoneBook phoneBook)
        {
            if (phoneBook == null)
                return false;
            if (phoneBook.Id == Guid.Empty)
                phoneBook.Id = Guid.NewGuid();
            _phoneBookContext.Contacts.Add(phoneBook);
            try
            {
                _phoneBookContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        [WebMethod]
        public bool UpdDict(PhoneBook phoneBook)
        {
            if (phoneBook == null)
                return false;
            _phoneBookContext.Entry(phoneBook).State = EntityState.Modified;
            try
            {
                _phoneBookContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public bool DelDict(PhoneBook phoneBook)
        {
            if (phoneBook == null)
                return false;
            var p = _phoneBookContext.Contacts.FirstOrDefault(x => x.Id == phoneBook.Id);
            if (p == null)
                return false;
            try
            {
                _phoneBookContext.Contacts.Remove(p);
                _phoneBookContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
