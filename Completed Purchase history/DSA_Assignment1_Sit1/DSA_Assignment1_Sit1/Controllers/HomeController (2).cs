using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Electros Ltd.!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
