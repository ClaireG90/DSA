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

namespace DSA_Assignment1_Sit1.Controllers
{
    public class UpdateFaultStatusController : Controller
    {
        //
        // GET: /UpdateFaultStatus/
        List<FaultLog> faultLogs = new FaultClient().GetAllFaultLogs().ToList();

        public ActionResult Index()
        {
            //Show all faults.
            
            return View(faultLogs);
        }

        public ActionResult Search(string username)
        {
            Account account = new UserAccountClient().GetAccountByUsername(username);
            List<Fault> faultList = new FaultClient().GetFaultsByAccountID(account.ID).ToList();

            List<FaultLog> faultLogList = new List<FaultLog>();

            foreach (Fault f in faultList)
            {
                List<FaultLog> flTemp = new FaultClient().GetAllFaultLogsByFaultID(f.ID).ToList();
                foreach (FaultLog fl in flTemp)
                {
                    faultLogList.Add(fl);
                }
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
    }
}
