using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voude.Areas.Admin.Models;

namespace Voude.Controllers
{
    public class HomeController : Controller
    {
        MyDBContext myContext = new MyDBContext();
        public ActionResult Index()
        {
            var data = myContext.PARTNERs.Where(x=>x.name != null).ToList();
            ViewBag.Partner = data;

            var hot = myContext.VOUCHERs.Where(x => x.hot == 1).ToList();
            ViewBag.hot = hot;
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
            var data = myContext.PARTNERs.Where(x => x.name != null).ToList();
            return View(data);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

      
    }
}