using lab_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_3.Controllers
{
    public class DictController : Controller
    {
        PhoneBookContext phoneBookContext;
        public ActionResult Index()
        {
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            ViewBag.PhoneBooks = phoneBookContext.PhoneBooks;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(string surname, string telephone)
        {
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            phoneBookContext.Add(surname, telephone);
            ViewBag.PhoneBooks = phoneBookContext.PhoneBooks;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Update(string idSelectedItem)
        {
            ViewBag.Id = idSelectedItem;
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            ViewBag.PhoneBooks = phoneBookContext.PhoneBooks;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(string id, string surname, string telephone)
        {
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            phoneBookContext.Update(Guid.Parse(id), surname, telephone);
            ViewBag.PhoneBooks = phoneBookContext.PhoneBooks;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(string delSelectedItem)
        {
            ViewBag.Id = delSelectedItem;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(string id)
        {
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            phoneBookContext.Delete(Guid.Parse(id));
            ViewBag.PhoneBooks = phoneBookContext.PhoneBooks;
            return View("Index");
        }
    }
}