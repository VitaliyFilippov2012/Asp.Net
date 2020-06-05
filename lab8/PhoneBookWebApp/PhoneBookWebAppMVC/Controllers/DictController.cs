using System;
using Microsoft.AspNetCore.Mvc;
using PhoneBookLibrary;

namespace PhoneBookWebAppMVC.Controllers
{
    public class DictController : Controller
    {
        private readonly IPhoneDictionary _phoneDictionary;

        public DictController(IPhoneDictionary phoneDictionary)
        {
            _phoneDictionary = phoneDictionary;
        }

        public ActionResult Index()
        {
            ViewBag.PhoneBooks = _phoneDictionary.GetPhoneBooks();
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
            _phoneDictionary.Add(surname, telephone);
            ViewBag.PhoneBooks = _phoneDictionary.GetPhoneBooks();
            return View("Index");
        }

        [HttpGet]
        public ActionResult Update(string idSelectedItem)
        {
            ViewBag.Id = idSelectedItem;
            ViewBag.PhoneBooks = _phoneDictionary.GetPhoneBooks();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(string id, string surname, string telephone)
        {
            _phoneDictionary.Update(Guid.Parse(id), surname, telephone);
            ViewBag.PhoneBooks = _phoneDictionary.GetPhoneBooks();
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
            _phoneDictionary.Delete(Guid.Parse(id));
            ViewBag.PhoneBooks = _phoneDictionary.GetPhoneBooks();
            return View("Index");
        }
    }
}