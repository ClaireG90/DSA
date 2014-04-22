using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DSA_Assignment1_Sit1.Models;
using DSA_Assignment1_Sit1.FaultServ;
using DSA_Assignment1_Sit1.UserAccountServ;
using System.Net.Mail;
using System.Collections;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class UpdateFaultStatusController : Controller
    {
        //
        // GET: /UpdateFaultStatus/
        List<FaultLog> faultLogs = new FaultClient().GetAllFaultLogs().ToList();
        List<FaultLog> faultLogList = new List<FaultLog>();
        public ActionResult Index()
        {
            //Show all faults.
            
            return View(faultLogs);
        }

        public ActionResult Search(string username, string faultID, string dateFrom, string dateTo)
        {
            if ((username != null || username != "") && (faultID == null || faultID == "") && (dateFrom == null || dateFrom == "") && (dateTo == null || dateTo == ""))
            {
                //WITH username

                Account account = new UserAccountClient().GetAccountByUsername(username);
                List<Fault> faultListWithAccount = new FaultClient().GetFaultsByAccountID(account.ID).ToList();

                foreach (Fault f in faultListWithAccount)
                {
                    List<FaultLog> flTemp = new FaultClient().GetAllFaultLogsByFaultID(f.ID).ToList();
                    foreach (FaultLog fl in flTemp)
                    {
                        faultLogList.Add(fl);
                    }
                }
            }
            else if ((username == null || username == "") && (faultID != null || faultID != "") && (dateFrom == null || dateFrom == "") && (dateTo == null || dateTo == ""))
            {
                //WITH faultID

                int fID = Convert.ToInt32(faultID);

                faultLogList = new FaultClient().GetAllFaultLogsByFaultID(fID).ToList();
            }
            else if ((username == null || username == "") && (faultID == null || faultID == "") && (dateFrom != null || dateFrom != "") && (dateTo != null || dateTo != ""))
            {
                //WITH DATES

                DateTime from = Convert.ToDateTime(dateFrom);
                DateTime to = Convert.ToDateTime(dateTo);

                faultLogList = new FaultClient().GetFaultLogsByDate(from, to).ToList();
            }
            else if ((username != null || !username.Equals("")) && (faultID != null || !faultID.Equals("")) && (dateFrom != null || !dateFrom.Equals("")) && (dateTo != null || !dateTo.Equals("")))
            {
                //ALL COMBINATIONS

                DateTime from = Convert.ToDateTime(dateFrom);
                DateTime to = Convert.ToDateTime(dateTo);
                int fID = Convert.ToInt32(faultID);

                Account account = new UserAccountClient().GetAccountByUsername(username);
                //List<Fault> faultListWithAccount = new FaultClient().GetFaultsByAccountID(account.ID).ToList();

                faultLogList = new FaultClient().GetFaultsByAllThreeCombinations(account.ID, fID, from, to).ToList();
            }
            else
            {
                //ERROR - CHOOSE EITHER ONE OR ALL.

                ModelState.AddModelError("", "Search must be done by either all three options, by username, by faultID, or by date-from and date-to.  Please enter the correct choice.");
            }

            return View("Index", faultLogList);
        }

        public ActionResult Update(int faultID)
        {
            GenerateFaultModel model = new GenerateFaultModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(GenerateFaultModel model, int faultID)
        {
            FaultLog faultLog = new FaultLog();
            faultLog.Status = model.Status;
            faultLog.Description = model.Description;
            faultLog.FaultID = faultID;
            faultLog.DateOfReport = DateTime.Today;

            new FaultClient().AddFaultLog(faultLog);
            faultLogs.Add(faultLog);

            Fault f = new FaultClient().GetFaultByID(faultID);

            User u = new UserAccountClient().GetUserByAccountID(f.AccountID);

            MailMessage newMessage = new MailMessage();
            newMessage.From = new MailAddress("electros@info.com");
            newMessage.To.Add(new MailAddress(u.Email));
            newMessage.Subject = "Fault Report";
            newMessage.Body = "One of our representatives just updated your product with the latest service.  Please check our website for the update details.";
            SmtpClient smtpClient = new SmtpClient("smtp.go.net.mt");
            smtpClient.Send(newMessage);

            return View("Index", faultLogs);

        }
        
        public ActionResult Sort()
        {
            faultLogList = new FaultClient().sortByDateDesc().ToList();

            return View("Index", faultLogList);
        }
    }
}
