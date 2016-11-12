using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using thing.Models;
namespace thing.Controllers
{
    public class HomeController : Controller
    {
        private MissingDogsEntities db = new MissingDogsEntities();
        public ActionResult Index()
        {
            return View(db.missings.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}