using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Voude.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
          
        }
        public ActionResult CouponsPage()
        {
            return View();

        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult DetailPromotion()
        {
            return View();
        }
        public ActionResult CategoryPromotion()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

      
    }
}