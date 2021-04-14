using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CoursController : Controller
    {
        private DemoEntities de = new DemoEntities();
        public ActionResult Cours()
        {
            ViewBag.listCours = de.Cours.ToList();
            return View();
        }
    }

    
}