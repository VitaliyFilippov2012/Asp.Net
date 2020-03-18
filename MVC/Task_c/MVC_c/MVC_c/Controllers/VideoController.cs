using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_c.Models;

namespace MVC_c.Controllers
{
    public class VideoController : Controller
    {
        private SampleContext _context;

        public VideoController()
        {
            _context = new SampleContext();
        }
        
        public ActionResult Add()
        {
            return View("Add");
        }

        public ActionResult Index()
        {
            var mas = Directory.GetFiles(Request.PhysicalApplicationPath + "media");
            for (var i = 0; i < mas.Length; i++)
            {
                mas[i] = Path.GetFileName(mas[i]);
            }
            ViewBag.Catalogs = mas;
            return View("View");
        }

        public FileStreamResult GetFile(string name)
        {
            var path = Request.PhysicalApplicationPath + "media\\" + name;
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(fileStream, "media/mp4");
        }

        public ActionResult GetVideo(string name)
        {
            ViewBag.VideoName = name;
            return View("GetVideo");
        }

        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload == null) 
                return RedirectToAction("Index");


            var fileName = System.IO.Path.GetFileName(upload.FileName);

            upload.SaveAs(Server.MapPath("~/media/" + fileName));

            return RedirectToAction("Index");
        }
    }
}