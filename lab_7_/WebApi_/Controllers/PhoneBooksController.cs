using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using WebApi_.Models;


namespace WebApi_.Controllers
{
    public class PhoneBooksController : ApiController
    {
        private readonly PhoneBookContext _db = new PhoneBookContext();

        [HttpGet]
        [Route("TS")]
        public async Task<IList<PhoneBook>> GetBooks()
        {
            return await _db.Books.ToListAsync();
        }

        [HttpGet]
        [Route("TS/{id}")]
        [ResponseType(typeof(PhoneBook))]
        public async Task<IHttpActionResult> GetPhoneBook(Guid id)
        {
            var phoneBook = await _db.Books.FindAsync(id);
            if (phoneBook == null)
                return NotFound();

            return Ok(phoneBook);
        }

        [HttpPut]
        [Route("TS")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhoneBook([FromBody]PhoneBook phoneBook)
        {
            _db.Entry(phoneBook).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("TS")]
        [ResponseType(typeof(PhoneBook))]
        public async Task<IHttpActionResult> PostPhoneBook([FromBody]PhoneBook phoneBook)
        {
            if (phoneBook == null)
                return StatusCode(HttpStatusCode.BadRequest);
            phoneBook.Id = Guid.NewGuid();
            _db.Books.Add(phoneBook);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("TS/{id}")]
        [ResponseType(typeof(PhoneBook))]
        public async Task<IHttpActionResult> DeletePhoneBook(Guid id)
        {
            var phoneBook = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (phoneBook == null)
                return StatusCode(HttpStatusCode.NotFound);
            try
            {
                _db.Books.Remove(phoneBook);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }

            return Ok(phoneBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}