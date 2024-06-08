using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDMVC.Controllers
{
    public class HomeController : Controller
    {
        CURDMVCDBContet _context = new CURDMVCDBContet();
        public ActionResult Index()
        {
            var Listofdata = _context.BhaktDetails.ToList();
            return View(Listofdata);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BhaktDetail model)
        {
            _context.BhaktDetails.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insterted Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.BhaktDetails.Where(x => x.BhaktId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(BhaktDetail model)
        {
            var data = _context.BhaktDetails.Where(x => x.BhaktId == model.BhaktId).FirstOrDefault();
            if(data != null)
            {
                data.BhaktName = model.BhaktName;
                data.DMV = model.DMV;
                data.Gender = model.Gender;
                data.MobileNo = model.MobileNo;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

       public ActionResult Details(int id)
        {
            var data = _context.BhaktDetails.Where(x => x.BhaktId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.BhaktDetails.Where(x => x.BhaktId == id).FirstOrDefault();
            _context.BhaktDetails.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Data Deleted Successfully";
            return RedirectToAction("index");
        }
    }
}