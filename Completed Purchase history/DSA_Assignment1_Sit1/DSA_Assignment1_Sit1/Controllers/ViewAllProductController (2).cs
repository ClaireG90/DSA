﻿using System;
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
        List<Product> productList = new List<Product>();

        [Authorize(Roles = "Administrator, User")]
        public ActionResult Index()
        {
            if (Session["accountID"] != null)
            {
                productList = new ProductClient().GetAllProducts().ToList();
                return View("Index", productList);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult Search(string category, string name, string priceFrom, string priceTo)
        {
            if (Session["accountID"] != null)
            {
                if ((category != null || category != "") && (name == null || name == "") && (priceFrom == null || priceFrom == "") && (priceTo == null || priceTo == ""))
                {
                    //With Category
                    Category c = new ProductClient().getCategoryByName(category.ToString());
                    if (c != null)
                    {
                        productList = new ProductClient().GetProductsByCategory(c.ID).ToList();
                    }
                    else
                    {
                        productList = new ProductClient().GetAllProducts().ToList();
                        ViewBag.Error = "Category not identified.";
                        return View("Index", productList);
                    }
                    return View("Index", productList);
                }
                else if ((category == null || category == "") && (name != null || name != "") && (priceFrom == null || priceFrom == "") && (priceTo == null || priceTo == ""))
                {
                    //With name
                    productList = new ProductClient().GetProductsByName(name).ToList();

                    if (productList.Count <= 0)
                    {
                        productList = new ProductClient().GetAllProducts().ToList();
                        ViewBag.Error = "No products retrieved with that name.";
                        return View("Index", productList);
                    }
                    else
                    {
                        return View("Index", productList);
                    }
                }
                else if ((category == null || category == "") && (name == null || name == "") && (priceFrom != null || priceFrom != "") && (priceTo != null || priceTo != ""))
                {
                    try
                    {
                        Convert.ToDecimal(priceFrom);
                        Convert.ToDecimal(priceTo);
                    }
                    catch (Exception e)
                    {
                        productList = new ProductClient().GetAllProducts().ToList();
                        ViewBag.Error = "Price not in correct format.";
                        return View("Index", productList);
                    }
                    //With prices
                    decimal from = Convert.ToDecimal(priceFrom);
                    decimal to = Convert.ToDecimal(priceTo);

                    productList = new ProductClient().GetProductsByPriceRange(from, to).ToList();

                    return View("Index", productList);
                }
                else
                {
                    return View("Index", new List<Product>());
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult HighestPriceFirst()
        {
            if (Session["accountID"] != null)
            {
                productList = new ProductClient().sortByPriceDesc().ToList();

                return View("Index", productList);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult LowestPriceFirst()
        {
            if (Session["accountID"] != null)
            {
                productList = new ProductClient().sortByPriceAsc().ToList();

                return View("Index", productList);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult DateListed()
        {
            if (Session["accountID"] != null)
            {
                productList = new ProductClient().sortByDateListed().ToList();

                return View("Index", productList);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult Details(int id)
        {
            double rating = new ProductClient().GetRatingsByProduct(id);

            Product pro = new ProductClient().GetProductByID(id);
            ViewAllProductModel m = new ViewAllProductModel();
            m.myProduct = pro;
            m.rating = rating;
            return View(m);
        }

        [Authorize(Roles = "Administrator, User")]
        public PartialViewResult ProductComments(int id)
        {
            List<Comment> commentList = new ProductCommentClient().GetCommentsByProductID(id).ToList();
            return PartialView("_comments", commentList);
        }

        [Authorize(Roles = "Administrator, User")]
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
                    int quantityToBuy;
                    try
                    {
                         quantityToBuy = Convert.ToInt32(model.quantity);
                    }
                    catch (Exception e)
                    {
                        ViewAllProductModel m = new ViewAllProductModel();
                        m.myProduct = new ProductClient().GetProductByID(model.myProduct.ID);
                        m.rating = new ProductClient().GetRatingsByProduct(model.myProduct.ID);
                        ViewBag.Error = "Please provide a valid quantity amount";
                        return View("Details", m);
                    }

                    if (quantityToBuy <= 0)
                    {
                        ViewAllProductModel m = new ViewAllProductModel();
                        m.myProduct = new ProductClient().GetProductByID(model.myProduct.ID);
                        m.rating = new ProductClient().GetRatingsByProduct(model.myProduct.ID);
                        ViewBag.Error = "Please provide a valid quantity amount";
                        return View("Details", m);
                    }
                    else
                    {
                        ProductOrder po = new ProductOrder();
                        po.ProductID = productID;
                        po.OrderID = order.ID;
                        po.Quantity = quantityToBuy;
                        po.WarrantyExpiry = DateTime.Today.AddYears(2);

                        new OrderClient().AddProductOrder(po);
                    }
                }
                else
                {
                    //Add to current Order.

                    Order order = new OrderClient().GetOrderByAccountAndStatus(accountID, os.ID);
                    int productID = model.myProduct.ID;
                    int quantityToBuy;
                    try
                    {
                        quantityToBuy = Convert.ToInt32(model.quantity);
                    }
                    catch (Exception e)
                    {
                        ViewAllProductModel m = new ViewAllProductModel();
                        m.myProduct = new ProductClient().GetProductByID(model.myProduct.ID);
                        m.rating = new ProductClient().GetRatingsByProduct(model.myProduct.ID);
                        ViewBag.Error = "Please provide a valid quantity amount";
                        return View("Details", m);
                    }

                    if (quantityToBuy <= 0)
                    {
                        ViewAllProductModel m = new ViewAllProductModel();
                        m.myProduct = new ProductClient().GetProductByID(model.myProduct.ID);
                        m.rating = new ProductClient().GetRatingsByProduct(model.myProduct.ID);
                        ViewBag.Error = "Please provide a valid quantity amount";
                        return View("Details", m);
                    }
                    else
                    {
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
            }
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
