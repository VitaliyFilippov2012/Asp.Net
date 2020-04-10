using lab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab03.Controllers
{
    public class DictController : Controller
    {
        PhoneBookContext phoneBookContext;
        public ActionResult Index()
        {
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            ViewBag.PhoneBooks = phoneBookContext.phoneBooks;
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
            ViewBag.PhoneBooks = phoneBookContext.phoneBooks;
            return View("Index");
        }
        [HttpGet]
        public ActionResult Update(string UpdSelectedItem)
        {
            ViewBag.Id = UpdSelectedItem;
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            ViewBag.PhoneBooks = phoneBookContext.phoneBooks;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSave(string id, string surname, string telephone)
        {
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            phoneBookContext.Update(Convert.ToInt32(id), surname, telephone);
            ViewBag.PhoneBooks = phoneBookContext.phoneBooks;
            return View("Index");
        }
        public ActionResult Delete(string delSelectedItem)
        {
            ViewBag.Id = delSelectedItem;
            return View();
        }
        [HttpPost]
        public ActionResult DeleteSave(string id)
        {
            phoneBookContext = new PhoneBookContext(Server.MapPath("~/Models/Data.json"));
            phoneBookContext.Delete(Convert.ToInt32(id));
            ViewBag.PhoneBooks = phoneBookContext.phoneBooks;
            return View("Index");
        }
    }
}