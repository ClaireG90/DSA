using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DSA_Assignment1_Sit1.ProductServ;
using DSA_Assignment1_Sit1.ProductCommentServ;
using DSA_Assignment1_Sit1.OrderServ;
using System.ComponentModel.DataAnnotations;
using DSA_Assignment1_Sit1.Models;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class ViewAllProductController : Controller
    {
        //
        // GET: /ViewAllProduct/

        public ActionResult Index()
        {
            if (Session["accountID"] != null)
            {
                List<Product> productList = new ProductClient().GetAllProducts().ToList();
                return View("Index", productList);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Details(int id)
        {
            Product pro = new ProductClient().GetProductByID(id);
            ViewAllProductModel m = new ViewAllProductModel();
            m.myProduct = pro;
            return View(m);
        }

        public PartialViewResult ProductComments(int id)
        {
            List<Comment> commentList = new ProductCommentClient().GetCommentsByProductID(id).ToList();
            return PartialView("_comments", commentList);
        }

        [HttpPost]
        public ActionResult Buy(ViewAllProductModel model)
        {
            OrderStatus os = new OrderClient().GetOrderStatusByName("Cart");
            int accountID = (int)Session["accountID"];

            if (Session["accountID"] != null)
            {
                if (new OrderClient().GetOrderByAccountAndStatus((int)Session["accountID"], os.ID) == null)
                {
                    //Create new Order.

                    DateTime now = DateTime.Today;

                    Order orderToAdd = new Order();
                    orderToAdd.AccountID = accountID;
                    orderToAdd.DateOfOrder = now;
                    orderToAdd.StatusID = os.ID;

                    new OrderClient().AddOrder(orderToAdd);

                    Order order = new OrderClient().GetOrderByAccountAndStatus(accountID, os.ID);
                    int productID = model.myProduct.ID;
                    int quantityToBuy = Convert.ToInt32(model.quantity);

                    ProductOrder po = new ProductOrder();
                    po.ProductID = productID;
                    po.OrderID = order.ID;
                    po.Quantity = quantityToBuy;
                    po.WarrantyExpiry = DateTime.Today.AddYears(2);

                    new OrderClient().AddProductOrder(po);
                }
                else
                {
                    //Add to current Order.

                    Order order = new OrderClient().GetOrderByAccountAndStatus(accountID, os.ID);
                    int productID = model.myProduct.ID;
                    int quantityToBuy = Convert.ToInt32(model.quantity);

                    ProductOrder po;

                    if (new OrderClient().GetProductOrderByOrderIDAndProductID(order.ID, productID) != null)
                    {
                        po = new OrderClient().GetProductOrderByOrderIDAndProductID(order.ID, productID);
                        po.Quantity = po.Quantity + quantityToBuy;
                        new OrderClient().UpdateProductOrder(po);
                    }
                    else
                    {
                        po = new ProductOrder();
                        po.ProductID = productID;
                        po.OrderID = order.ID;
                        po.Quantity = quantityToBuy;
                        po.WarrantyExpiry = DateTime.Today.AddYears(2);
                        new OrderClient().AddProductOrder(po);
                    }
                }
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
