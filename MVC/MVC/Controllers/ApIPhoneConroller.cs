using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class ApIPhoneConroller : ApiController
    {
        private SampleContext db = new SampleContext();

        public IQueryable<Contact> GetPersons()
        {
            return db.Contacts;
        }


        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> GetContactsAsync(string id)
        {
            var contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContactAsync(string id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Phone)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            { 
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> PostContactAsync(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactExists(contact.Phone))
                {
                    return Conflict();
                }

                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = contact.Phone }, contact);
        }


        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContactAsync(string id)
        {
            var contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(string id)
        {
            return db.Contacts.Any(e => e.Phone == id);
        }
    }
}