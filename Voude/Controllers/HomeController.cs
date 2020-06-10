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
        public ActionResult DetailPromotion(long id)
        {
            var amthuc = myContext.VOUCHERs.Count(x => x.categoryId == 1);ViewBag.AT = amthuc;
            var muasam = myContext.VOUCHERs.Count(x => x.categoryId == 2); ViewBag.MS = muasam;
            var suckhoe = myContext.VOUCHERs.Count(x => x.categoryId == 3); ViewBag.SK = suckhoe;
            var dulich = myContext.VOUCHERs.Count(x => x.categoryId == 4); ViewBag.DL = dulich;
            var giaoduc = myContext.VOUCHERs.Count(x => x.categoryId == 5); ViewBag.GD = giaoduc;
            var lamdep = myContext.VOUCHERs.Count(x => x.categoryId == 6); ViewBag.LD = lamdep;

            var a = myContext.VOUCHERs.Where(x=>x.id == id).FirstOrDefault();          
            var b = myContext.VOUCHERs.Where(x=>x.categoryId == a.categoryId && x.id != a.id).ToList();
            ViewBag.SPCL = b;
           
            return View(a);
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
        public ActionResult Cart()
        {
            return View();

        }

        [HttpGet]
        public ActionResult Login(CUSTOMER customer)
        {
            var result = myContext.CUSTOMERs.Where(c => (c.username == customer.username && c.password == customer.password)).FirstOrDefault();
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
            var result = myContext.CUSTOMERs.Where(c => c.username == customer.username).FirstOrDefault();
            if (result == null)
            {
                myContext.CUSTOMERs.Add(customer);
                myContext.SaveChanges(); // luu thay doi
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Home");
            }
        }


    }
}