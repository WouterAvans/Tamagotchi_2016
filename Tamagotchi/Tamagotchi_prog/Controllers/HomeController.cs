using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamagotchi_prog.Models;

namespace Tamagotchi_prog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            using (var context = new MyContext())
            {
                ViewBag.Message = "Your application description page.";
                return View(context.Tamagotchis.ToList());
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}