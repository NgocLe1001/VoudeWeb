using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voude.Models;
namespace Voude.Controllers
{
    public class CategoryController : Controller

    {
        VOUCHER product;
        private Model1 myContext = new Model1();
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
            var data = myContext.VOUCHERs.Where(x => x.categoryId == 5).ToList();
            ViewBag.GiaoDuc = data;
            return View();
        }

        public ActionResult LamDepPage()
        {
            var data = myContext.VOUCHERs.Where(x => x.categoryId == 6).ToList();
            ViewBag.LamDep = data;
            return View();
        }
        //public ActionResult AddItem(int idCategory,int  idVoucher)
        //{
        //    var data = myContext.VOUCHERs.Where(x => x.categoryId == idCategory).ToList();


        //    foreach(var it in data)
        //    {
        //        if (it.id == idVoucher)
        //        {
        //            product = it;
        //        }
        //    }
        //    var cart = (Cart)Session["CartSession"];
        //    if (cart != null)
        //    {
        //        cart.AddItem(product, 1);
        //        //Gán vào session
        //        Session["CartSession"] = cart;
        //        // điều hướng
        //        return RedirectToAction("Cart","Home");
        //    }
        //    else
        //    {
        //        //tạo mới đối tượng cart item
        //        cart = new Cart();
        //        cart.AddItem(product, 1);
        //        //Gán vào session
        //        Session["CartSession"] = cart;
        //        // điều hướng
        //        return RedirectToAction("Cart", "Home");
        //    }


        //}
        public ActionResult AddItem(int idVoucher)
        {
            product = myContext.VOUCHERs.Where(x => x.id == idVoucher).FirstOrDefault();

            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
                // điều hướng
                return RedirectToAction("Cart", "Home");
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
                // điều hướng
                return RedirectToAction("Cart", "Home");
            }
        }
    }
}