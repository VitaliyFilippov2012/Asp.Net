using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
        readonly SampleContext db = new SampleContext();

        public ActionResult Index()
        {
            return View("Browse", db.Contacts);
        }
        
        public ActionResult AddAsync()
        {
            ViewBag.Message = "Your application description page.";

            return View("Add");
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([Bind(Include = "Surname,Firstname,Middlename,BDay,Phone")] Contact contact)
        {
            if (contact.BDay < DateTime.Now.AddYears(-120))
            {
                ModelState.AddModelError("BirthDate", "Error in birth date");
            }

            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            else
                return View("Error");
        }

        public async Task<ActionResult> UpdateAsync(string phone)
        {
            var contact = await db.Contacts.FirstAsync(c => c.Phone == phone);
            return View("Update", contact);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAsync([Bind(Include = "Surname,Firstname,Middlename,BDay,Phone")] Contact contact)
        {
            if (!ModelState.IsValid)
                return View("Error");

            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<ActionResult> DeleteAsync(string phone)
        {
            if(phone == null)
                return RedirectToAction("Add");
            var p = await db.Contacts.FirstAsync(c => c.Phone == phone);
            if (p == null)
                return RedirectToAction("Index");
            db.Contacts.Remove(p);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("Add");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}