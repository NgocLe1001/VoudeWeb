using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voude.Areas.Admin.Models;

namespace Voude.Controllers
{
    public class CategoryController : Controller
    {
        MyDBContext myContext = new MyDBContext();
        // GET: Category
        public ActionResult AmThucPage()
        {
            var data = myContext.VOUCHERs.Where(x => x.categoryId == 1).ToList();
            ViewBag.AmThuc = data;

            return View();
        }

        public ActionResult MuaSamPage()
        {
            var data = myContext.VOUCHERs.Where(x => x.categoryId == 2).ToList();
            ViewBag.MuaSam = data;
            return View();
        }

        public ActionResult SucKhoePage()
        {
            var data = myContext.VOUCHERs.Where(x => x.categoryId == 3).ToList();
            ViewBag.SucKhoe = data;
            return View();
        }
        public ActionResult DuLichPage()
        {
            var data = myContext.VOUCHERs.Where(x => x.categoryId == 4).ToList();
            ViewBag.DuLich = data;
            return View();
        }
        public ActionResult GiaoDucPage()
        {
            return View();
        }

        public ActionResult LamDepPage()
        {
            return View();
        }
        
    }
}