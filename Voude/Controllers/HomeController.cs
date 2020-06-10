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
        VOUCHER product;
        long activeId;
        public ActionResult Index()
        {
            var hot = context.VOUCHERs.Where(x => x.hot == 1).ToList();
            var data = context.PARTNERs.Where(x => x.name != null).ToList();
            var newest = context.VOUCHERs.Where(x => x.name != null).ToList();
            ViewBag.Partner = data;
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
            var amthuc = context.VOUCHERs.Count(x => x.categoryId == 1); ViewBag.AT = amthuc;
            var muasam = context.VOUCHERs.Count(x => x.categoryId == 2); ViewBag.MS = muasam;
            var suckhoe = context.VOUCHERs.Count(x => x.categoryId == 3); ViewBag.SK = suckhoe;
            var dulich = context.VOUCHERs.Count(x => x.categoryId == 4); ViewBag.DL = dulich;
            var giaoduc = context.VOUCHERs.Count(x => x.categoryId == 5); ViewBag.GD = giaoduc;
            var lamdep = context.VOUCHERs.Count(x => x.categoryId == 6); ViewBag.LD = lamdep;

            var a = context.VOUCHERs.Where(x => x.id == id).FirstOrDefault();
            var b = context.VOUCHERs.Where(x => x.categoryId == a.categoryId && x.id != a.id).ToList();
            ViewBag.SPCL = b;

            var diachi = context.SHOPs.Where(x => x.partnerId == a.partnerId).ToList();
            ViewBag.DC = diachi;

            return View(a);
          
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
            Cart cart;
            cart = (Cart)Session["CartSession"];
            if(cart == null)
            {
                cart = new Cart();
            }

            return View(cart);

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
                Session["activeUser"] = customer;
                activeId = customer.id;
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
                Session["activeUser"] = customer;
                activeId = customer.id;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Home");
            }
  


        }

        public ActionResult AddItem(int idVoucher)
        {
            product = context.VOUCHERs.Where(x => x.id == idVoucher).FirstOrDefault();

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
        public ActionResult DecreaseItem(int idVoucher)
        {
            product = context.VOUCHERs.Where(x => x.id == idVoucher).FirstOrDefault();

            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                cart.DecreaseItem(idVoucher);
                //Gán vào session
                Session["CartSession"] = cart;
                // điều hướng
                return RedirectToAction("Cart", "Home");
            }
            else
            {
                
                return RedirectToAction("Cart", "Home");
            }
        }
        public ActionResult IncreaseItem(int idVoucher)
        {
            product = context.VOUCHERs.Where(x => x.id == idVoucher).FirstOrDefault();

            var cart = (Cart)Session["CartSession"];
            if (cart != null)
            {
                cart.IncreaseItem(idVoucher);
                //Gán vào session
                Session["CartSession"] = cart;
                // điều hướng
                return RedirectToAction("Cart", "Home");
            }
            else
            {

                return RedirectToAction("Cart", "Home");
            }
        }


        public ActionResult RemoveLine(int id)
        {

            var product = context.VOUCHERs.Find(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Cart");
        }
        public ActionResult UpdateCart(int[] idVoucher, int[] qty)
        {
            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                for (int i = 0; i < idVoucher.Count(); i++)
                {
                    var product = context.VOUCHERs.Find(idVoucher[i]);
                    cart.UpdateItem(product, qty[i]);
                }

                Session["CartSession"] = cart;
            }

            return RedirectToAction("Cart");

        }


        [HttpGet]
        public ActionResult Payment()
        {
            var cart = (Cart)Session["CartSession"];
            if (cart == null)
            {
                cart = new Cart();
            }
            return View(cart);
        }

        [HttpPost]
        public ActionResult Payment(INVOICE invoice)
        {
            invoice.time = DateTime.Now;
            try
            {
                context.INVOICEs.Add(invoice);
                context.SaveChanges();
                var cart = (Cart)Session["CartSession"];
                foreach (var item in cart.Lines)
                {
                    DETAIL_INVOICE obj = new DETAIL_INVOICE();
                    obj.invoiceId = invoice.id;
                    obj.voucherId = item.Voucher.id;
                    //obj.DonGia = item.Sanpham.GiaSP;
                    obj.quantity = item.Quantity;

                    context.DETAIL_INVOICE.Add(obj);
                    context.SaveChanges();
                }
                cart.Clear();
                Session["CartSession"] = cart;
            }
            catch (Exception ex)
            {
                //ghi log
                return RedirectToAction("/Loi");
            }
            return View("Complete");
        }


    }
}