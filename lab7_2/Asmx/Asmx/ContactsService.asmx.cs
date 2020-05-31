using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Services;

namespace Asmx
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
        private readonly PhoneBookContext _phoneBookContext;

        public ContactsService()
        {
            _phoneBookContext = new PhoneBookContext();
        }

        [WebMethod]
        public async Task<IList<PhoneBook>> GetDict()
        {
            return await _phoneBookContext.Books.ToListAsync();
        }

        [WebMethod]
        public async Task<bool> AddDict(PhoneBook phoneBook)
        {
            if (phoneBook == null)
                return false;
            if(phoneBook.Id == Guid.Empty)
                phoneBook.Id = Guid.NewGuid();
            _phoneBookContext.Books.Add(phoneBook);
            try
            {
                await _phoneBookContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        [WebMethod]
        public async Task<bool> UpdDict(PhoneBook phoneBook)
        {
            _phoneBookContext.Entry(phoneBook).State = EntityState.Modified;
            try
            {
                await _phoneBookContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public async Task<bool> DelDict(PhoneBook phoneBook)
        {
            if (phoneBook == null)
                return false;
            var p = await _phoneBookContext.Books.FirstOrDefaultAsync(x => x.Id == phoneBook.Id);
            if (p == null)
                return false;
            try
            {
                _phoneBookContext.Books.Remove(phoneBook);
                await _phoneBookContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
