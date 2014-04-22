using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSA_Assignment1_Sit1.Models;
using Common;
using DSA_Assignment1_Sit1.OrderServ;
using DSA_Assignment1_Sit1.ProductServ;
using DSA_Assignment1_Sit1.ProductCommentServ;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class ShoppingCartController : Controller
    {
        List<ProductOrder> allPO = new List<ProductOrder>();

        public ActionResult Index()
        {
            if (Session["accountID"] != null)
            {
                Order order = new OrderClient().GetOrderByAccountAndStatus((int)Session["accountID"], new OrderClient().GetOrderStatusByName("Cart").ID);
                if (order != null)
                {
                    List<ProductOrder> productList = new OrderClient().GetProductOrderByOrderID(order.ID).ToList();

                    double totalPrice = 0.0;

                    foreach (ProductOrder po in productList)
                    {
                        Product p = new ProductClient().GetProductByID(po.ProductID);
                        totalPrice += (Convert.ToDouble(p.Price) * po.Quantity);
                    }
                    ViewBag.TotalPrice = "Total Order Price: " +  totalPrice.ToString();
                    return View("Index", productList);
                }
                else
                {
                    return View("Index", new List<ProductOrder>());
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult PurchaseHistory(ViewAllProductModel model)
        {
            if(Session["accountID"] != null)
            {
                List<Order> orderList = new OrderClient().GetBoughtOrdersByAccountID((int)Session["accountID"]).ToList(); 

                foreach (Order o in orderList)
                {
                    List<ProductOrder> productOrderlist = new OrderClient().GetProductOrderByOrderID(o.ID).ToList();

                    foreach (ProductOrder po in productOrderlist)
                    {
                        allPO.Add(po);
                    }
                }
                return View("PurchaseHistory", allPO);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult FilterTransactions(string dateFrom, string dateTo)
        {
            if ((dateFrom != null || dateFrom != "") && (dateTo != null || dateTo != ""))
            {
                DateTime from = Convert.ToDateTime(dateFrom);
                DateTime to = Convert.ToDateTime(dateTo);

                if (Session["accountID"] != null)
                {
                    List<Order> orderList = new OrderClient().getOrdersByAccountAndDates((int)Session["accountID"], from, to).ToList();

                    foreach (Order o in orderList)
                    {
                        List<ProductOrder> productOrderlist = new OrderClient().GetProductOrderByOrderID(o.ID).ToList();

                        foreach (ProductOrder po in productOrderlist)
                        {
                            allPO.Add(po);
                        }
                    }
                    return View("PurchaseHistory", allPO);
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                return View("PurchaseHistory", allPO);
            }
        }

        public ActionResult CheckOut()
        {
            if (Session["accountID"] != null)
            {
                Order order = new OrderClient().GetOrderByAccountAndStatus((int)Session["accountID"], new OrderClient().GetOrderStatusByName("Cart").ID);
                OrderStatus status = new OrderClient().GetOrderStatusByName("Bought");
                order.StatusID = status.ID;
                new OrderClient().UpdateOrder(order);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public PartialViewResult ProductDetails(int pID, int oID)
        {
            ProductOrder po = new OrderClient().GetProductOrderByOrderIDAndProductID(oID, pID);



            return PartialView("_productDetails", po);
        }

        public ActionResult PostComment(int pID)
        {
            Product p = new ProductClient().GetProductByID(pID);
            CommentModel cm = new CommentModel();
            cm.myProduct = p;
            return View(cm);
        }

        [HttpPost]
        public ActionResult PostComment(CommentModel model, int pID)
        {
            if (Session["accountID"] != null)
            {
                Comment comment = new Comment();
                comment.AccountID = (int)Session["accountID"];
                comment.ProductID = pID;
                comment.Comment1 = model.commnet;

                new ProductCommentClient().AddComment(comment);

                return RedirectToAction("PurchaseHistory");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Delete(int productID)
        {
            if (Session["accountID"] != null)
            {
                Order order = new OrderClient().GetOrderByAccountAndStatus((int)Session["accountID"], new OrderClient().GetOrderStatusByName("Cart").ID);

                new OrderClient().DeleteProductOrder(order.ID, productID);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
