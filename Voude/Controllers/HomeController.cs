using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voude.Models;

namespace Voude.Controllers
{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();
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
        public ActionResult Cart()
        {
            return View();

        }
        [HttpGet]

        public ActionResult Login(CUSTOMER customer)
        {
            var result = context.CUSTOMERs.Where(c => (c.username == customer.username && c.password == customer.password)).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("Register", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public ActionResult RegisterCheck(CUSTOMER customer)
        {
            var result = context.CUSTOMERs.Where(c => c.username == customer.username).FirstOrDefault();
            if (result == null)
            {
                context.CUSTOMERs.Add(customer);
                context.SaveChanges(); // luu thay doi
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Home");
            }
  


        }

    }
}