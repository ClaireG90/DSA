using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DSA_Assignment1_Sit1.ProductServ;
using DSA_Assignment1_Sit1.FaultServ;
using DSA_Assignment1_Sit1.Models;
using DSA_Assignment1_Sit1.UserAccountServ;
using DSA_Assignment1_Sit1.OrderServ;
using DSA_Assignment1_Sit1.BarcodeServ;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class GenerateFaultController : Controller
    {
        //
        // GET: /GenerateFault/

        public static int randomNum = 0;
        public ActionResult Index()
        {          
            if(Session["accountID"] != null)
            {
                List<Order> orderList = new OrderClient().GetBoughtOrdersByAccountID((int)Session["accountID"]).ToList();

                List<ProductOrder> allPO = new List<ProductOrder>();

                foreach (Order o in orderList)
                {
                    List<ProductOrder> productOrderlist = new OrderClient().GetWarrantyUnexpiredOrdersByOrderID(o.ID).ToList();

                    foreach (ProductOrder po in productOrderlist)
                    {
                        allPO.Add(po);
                    }
                }
                return View("Index", allPO);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
       
        }

        public ActionResult ReportFault(GenerateFaultModel model)
        {
            if (Session["accountID"] != null)
            {
                //model.myProduct = new ProductClient().GetProductByID(pID);
                return View("ReportFault") ;
            }
            else 
            {
                return RedirectToAction("Login", "Login");
            }

        }

        [HttpPost]
        public ActionResult ReportFault(GenerateFaultModel model, int pID)
        {
            if (Session["accountID"] != null)
            {
                int ticketNumber;
                bool available = false;

                do
                {
                    ticketNumber = new FaultClient().GenerateRandomNumber();
                    if (new FaultClient().GetFaultByTicketNumber(ticketNumber) != null)
                    {
                        ticketNumber = new FaultClient().GenerateRandomNumber();
                        available = false;
                    }
                    else
                    {
                        available = true;
                    }
                }
                while (!available);

                BarCodeData barCodeData = new BarCodeData();
                barCodeData.Height = 125;
                barCodeData.Width = 225;
                barCodeData.Angle = 0;
                barCodeData.Ratio = 5;
                barCodeData.Module = 0;
                barCodeData.Left = 25;
                barCodeData.Top = 0;
                barCodeData.CheckSum = false;
                barCodeData.FontName = "Arial";
                barCodeData.BarColor = "Black";
                barCodeData.BGColor = "White";
                barCodeData.FontSize = 10.0f;
                barCodeData.barcodeOption = BarcodeOption.Both;
                barCodeData.barcodeType = BarcodeType.Code_2_5_interleaved;
                barCodeData.checkSumMethod = CheckSumMethod.None;
                barCodeData.showTextPosition = ShowTextPosition.BottomCenter;
                barCodeData.BarCodeImageFormat = ImageFormats.PNG;

                Byte[] imgBarcode = new BarCodeSoapClient().GenerateBarCode(barCodeData, randomNum.ToString());

                MemoryStream memStream = new MemoryStream(imgBarcode);
                Bitmap bm = new Bitmap(memStream);
                bm.Save(HttpContext.Response.OutputStream, ImageFormat.Jpeg);

                System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgBarcode));

                Fault fault = new Fault();
                fault.TicketNumber = ticketNumber;
                fault.ProductID = pID;
                fault.AccountID = (int)Session["accountID"];
                fault.Barcode = imgBarcode;

                new FaultClient().AddFault(fault);

                FaultLog faultLog = new FaultLog();
                faultLog.FaultID = new FaultClient().GetFaultByTicketNumber(ticketNumber).ID;
                faultLog.Description = model.Description;
                faultLog.DateOfReport = DateTime.Today;
                faultLog.Status = "Reported";

                new FaultClient().AddFaultLog(faultLog);
                User user = new UserAccountClient().GetUserByAccountID((int)Session["accountID"]);

                memStream.Position = 0;
                string body = string.Format(@"A new fault report has been made. Please find attached your barcode image.");


                //SEND EMAIL HERE
                MailMessage newMessage = new MailMessage();
                newMessage.From = new MailAddress("electros@info.com");
                newMessage.To.Add(new MailAddress(user.Email));
                newMessage.Subject = "Fault Report";
                newMessage.Attachments.Add(new Attachment(memStream, "Barcodeimg.jpg", "image/jpg"));
                newMessage.Body = body;
                SmtpClient smtpClient = new SmtpClient("smtp.go.net.mt");
                smtpClient.Send(newMessage);

                return RedirectToAction("Index", "GenerateFault");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
       
        public ActionResult GenerateBarcode()
        {

            BarCodeSoapClient bc = new BarCodeSoapClient();

            BarCodeData barCodeData = new BarCodeData();
            barCodeData.Height = 125;
            barCodeData.Width = 225;
            barCodeData.Angle = 0;
            barCodeData.Ratio = 5;
            barCodeData.Module = 0;
            barCodeData.Left = 25;
            barCodeData.Top = 0;
            barCodeData.CheckSum = false;
            barCodeData.FontName = "Arial";
            barCodeData.BarColor = "Black";
            barCodeData.BGColor = "White";
            barCodeData.FontSize = 10.0f;
            barCodeData.barcodeOption = BarcodeOption.Both;
            barCodeData.barcodeType = BarcodeType.Code_2_5_interleaved;
            barCodeData.checkSumMethod = CheckSumMethod.None;
            barCodeData.showTextPosition = ShowTextPosition.BottomCenter;
            barCodeData.BarCodeImageFormat = ImageFormats.PNG;

            Random r = new Random();
            randomNum = r.Next(1000);

            Byte[] imgBarcode = bc.GenerateBarCode(barCodeData, randomNum.ToString());

            MemoryStream memStream = new MemoryStream(imgBarcode);
            Bitmap bm = new Bitmap(memStream);
            bm.Save(HttpContext.Response.OutputStream, ImageFormat.Jpeg);

            System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgBarcode));

            return new FileStreamResult(memStream, "image/png");

        }

    }
}
