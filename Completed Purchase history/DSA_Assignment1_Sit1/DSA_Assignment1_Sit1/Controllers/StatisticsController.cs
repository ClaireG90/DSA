using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DSA_Assignment1_Sit1.ProductServ;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class StatisticsController : Controller
    {
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            if (Session["accountID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator")]
        public PartialViewResult HighestRatedItem()
        {
            List<Rating> ratings = new ProductClient().GetHighlyRatedItem().ToList();
            Product p;
            Rating r = new Rating();
            foreach (Rating rate in ratings)
            {
                r = rate;
            }

            p = new ProductClient().GetProductByID(r.ProductID);
            ViewBag.Rating = r.Rating1;

            return PartialView("_highestRatedItem", p);
        }

        [Authorize(Roles = "Administrator")]
        public PartialViewResult MostPurchasedItem()
        {
            List<ProductOrder> poList = new ProductClient().GetMostPurchasedItem().ToList();
            Product p;
            ProductOrder po = new ProductOrder();
            foreach (ProductOrder prodOrder in poList)
            {
                po = prodOrder;
            }
            p = new ProductClient().GetProductByID(po.ProductID);

            return PartialView("_mostPurchasedItem", p);
        }

        [Authorize(Roles = "Administrator")]
        public PartialViewResult ProductWithMostFaults()
        {
            List<Fault> poList = new ProductClient().GetProductWithMostFaults().ToList();
            Product p;
            Fault f = new Fault();
            foreach (Fault tempF in poList)
            {
                f = tempF;
            }
            p = new ProductClient().GetProductByID(f.ProductID);

            return PartialView("_productWithMostFaults", p);
        }

        [Authorize(Roles = "Administrator")]
        public PartialViewResult ProductWithLeastFaults()
        {
            List<Fault> poList = new ProductClient().GetProductWithLeastFaults().ToList();
            Product p;
            Fault f = new Fault();
            foreach (Fault tempF in poList)
            {
                f = tempF;
            }
            p = new ProductClient().GetProductByID(f.ProductID);

            return PartialView("_productWithLeastFaults", p);
        }
    }
}
