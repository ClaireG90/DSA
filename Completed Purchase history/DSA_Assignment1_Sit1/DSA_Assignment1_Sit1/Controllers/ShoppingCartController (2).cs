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
using DSA_Assignment1_Sit1.FaultServ;
using DSA_Assignment1_Sit1.UserAccountServ;
using System.Net.Mail;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class ShoppingCartController : Controller
    {
        List<ProductOrder> allPO = new List<ProductOrder>();
        DateTime from;
        DateTime to;

        PrintStatementModel model = new PrintStatementModel();

        [Authorize(Roles = "Administrator, User")]
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

        [Authorize(Roles = "Administrator, User")]
        public ActionResult PurchaseHistory(ViewAllProductModel model)
        {
            try
            {
                if (Session["accountID"] != null)
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
            catch (Exception e)
            {
                ViewBag.Error = "An error has occured.";
                return View("PurchaseHistory", new List<ProductOrder>());
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult FilterTransactions(string dateFrom, string dateTo)
        {
            try
            {
                if ((dateFrom != null || dateFrom != "") && (dateTo != null || dateTo != ""))
                {
                    try
                    {
                        from = Convert.ToDateTime(dateFrom);
                        to = Convert.ToDateTime(dateTo);
                    }
                    catch (Exception e)
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
                        ViewBag.Error = "Dates not in correct format (2014/01/01)";
                        return View("PurchaseHistory", allPO);
                    }
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
            catch (Exception e)
            {
                ViewBag.Error = "An error has occured.";
                return RedirectToAction("PurchaseHistory", allPO);
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult CheckOut()
        {
            if (Session["accountID"] != null)
            {
                Order order = new OrderClient().GetOrderByAccountAndStatus((int)Session["accountID"], new OrderClient().GetOrderStatusByName("Cart").ID);
                OrderStatus status = new OrderClient().GetOrderStatusByName("Bought");
                order.StatusID = status.ID;
                Order newOrder = new Order();
                newOrder.StatusID = status.ID;
                newOrder.ID = order.ID;
                newOrder.DateOfOrder = order.DateOfOrder;
                newOrder.AccountID = order.AccountID;
                //new OrderClient().UpdateOrder(order);
                new OrderClient().UpdateOrder(newOrder);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator, User")]
        public PartialViewResult ProductDetails(int pID, int oID)
        {
            ProductOrder po = new OrderClient().GetProductOrderByOrderIDAndProductID(oID, pID);
            return PartialView("_productDetails", po);
        }

        [Authorize(Roles = "Administrator, User")]
        public ActionResult PostComment(int pID)
        {
            Product p = new ProductClient().GetProductByID(pID);
            CommentModel cm = new CommentModel();
            cm.myProduct = p;
            return View(cm);
        }

        [Authorize(Roles = "Administrator, User")]
        [HttpPost]
        public ActionResult PostComment(CommentModel model, int pID)
        {
            try
            {
                if (Session["accountID"] != null)
                {
                    Rating rating = new Rating();
                    Rating tempR = new ProductClient().GetRatingByAccountAndProduct((int)Session["accountID"], pID);

                    if (tempR == null)
                    {
                        rating.ProductID = pID;
                        rating.AccountID = (int)Session["accountID"];
                        rating.Rating1 = model.rating;

                        Comment comment = new Comment();
                        comment.AccountID = (int)Session["accountID"];
                        comment.ProductID = pID;
                        comment.Comment1 = model.commnet;

                        new ProductCommentClient().AddComment(comment);
                        new ProductClient().AddRating(rating);
                        return RedirectToAction("PurchaseHistory");
                    }
                    else
                    {
                        ViewBag.Error = "You already posted a rating for this product.";
                        return View("PostComment", model);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "An error has occured.";
                return View("PostComment", model);
            }
        }

        [Authorize(Roles = "Administrator, User")]
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

        [Authorize(Roles = "Administrator, User")]
        public ActionResult ShowReport(int pID, int oID)
        {
            try
            {
                PrintStatementModel model = new PrintStatementModel();
                Order o = new OrderClient().GetOrderByID(oID);
                model.myOrder = o;

                ProductOrder po = new OrderClient().GetProductOrderByOrderIDAndProductID(o.ID, pID);
                model.myProductOrder = po;

                List<FaultLog> fl = new List<FaultLog>();

                Product p = new ProductClient().GetProductByID(pID);
                model.myProduct = p;

                List<Fault> f = new FaultClient().GetFaultsByAccountIDandProductID((int)Session["accountID"], pID).ToList();
                model.myFaultList = f;

                Common.FaultLog faultLog = new Common.FaultLog();
                List<Common.FaultLog> faultLogList = new List<Common.FaultLog>();
                List<Common.Fault> flist = new List<Common.Fault>();


                flist = new DSA_Assignment1_Sit1.FaultServ.FaultClient().GetFaultsByAccountIDandProductID((int)Session["accountID"], pID).ToList();

                foreach (Common.Fault fa in flist)
                {
                    List<Common.FaultLog> flTemp = new DSA_Assignment1_Sit1.FaultServ.FaultClient().GetAllFaultLogsByFaultID(fa.ID).ToList();

                    model.myFaultLog = flTemp;
                }

                if (model.myFaultLog == null)
                {
                    List<Order> orderList = new OrderClient().GetBoughtOrdersByAccountID((int)Session["accountID"]).ToList();

                    foreach (Order or in orderList)
                    {
                        List<ProductOrder> productOrderlist = new OrderClient().GetProductOrderByOrderID(or.ID).ToList();

                        foreach (ProductOrder por in productOrderlist)
                        {
                            allPO.Add(por);
                        }
                    }

                    ViewBag.Error = "No fault logs recorded.";
                    return RedirectToAction("PurchaseHistory", allPO);
                }
                //SEND EMAIL

                //get user email
                User user = new UserAccountClient().GetUserByAccountID((int)Session["accountID"]);

                //Render email

                Document document = new Document();
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();
                document.Add(new Paragraph("Electros Ltd."));
                document.Add(new Paragraph());
                document.Add(new Paragraph("Item: "));
                document.Add(new Paragraph("Product ID          " + "Name                    " + "Price          " + "Date Of Purchase         " + "Warranty Expiry"));
                document.Add(new Paragraph(model.myProduct.ID + "                    " + model.myProduct.Name + "          " + model.myProduct.Price + "          " + model.myOrder.DateOfOrder.ToShortDateString() + "             " + model.myProductOrder.WarrantyExpiry.ToShortDateString()));
                document.Add(new Paragraph());
                document.Add(new Paragraph("Faults: "));
                document.Add(new Paragraph("Fault ID          Date          Fault Details                              Status"));
                foreach (FaultLog flo in model.myFaultLog)
                {
                    document.Add(new Paragraph(flo.FaultID + "          " + flo.DateOfReport.ToShortDateString() + "          " + flo.Description + "                              " + flo.Status));
                }
                writer.CloseStream = false;
                document.Close();
                memoryStream.Position = 0;

                MailMessage newMessage = new MailMessage();
                newMessage.From = new MailAddress("electros@info.com");
                newMessage.To.Add(new MailAddress(user.Email));
                newMessage.Subject = "Print Statement";
                newMessage.Body = "Dear " + user.Name + " " + user.Surname + ",  please find attached details of the product's faults.";
                Attachment attachment = new Attachment(memoryStream, "ReportStatement.pdf");
                newMessage.Attachments.Add(attachment);
                SmtpClient smtpClient = new SmtpClient("smtp.go.net.mt");
                smtpClient.Send(newMessage);

                return new RazorPDF.PdfResult(model, "ShowReport");
            }
            catch (Exception e)
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
                ViewBag.Error = "An error has occured.";
                return RedirectToAction("PurchaseHistory" , allPO);
            }
        }
    }
}
