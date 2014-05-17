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
using System.Net;
using System.IO;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class UpdateFaultStatusController : Controller
    {
        //
        // GET: /UpdateFaultStatus/
        List<FaultLog> faultLogs = new FaultClient().GetAllFaultLogs().ToList();
        List<FaultLog> faultLogList = new List<FaultLog>();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            //Show all faults.
            if (Session["accountID"] != null)
            {
                return View(faultLogs);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Search(string username, string faultID, string dateFrom, string dateTo)
        {
            if (Session["accountID"] != null)
            {
                if ((username != null || username != "") && (faultID == null || faultID == "") && (dateFrom == null || dateFrom == "") && (dateTo == null || dateTo == ""))
                {
                    //WITH username
                    if (new UserAccountClient().GetAccountByUsername(username) != null)
                    {
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
                    else
                    {
                        TempData["Error"] = "Username doesn't exist.";
                        return RedirectToAction("Index", faultLogs);
                    }
                }
                else if ((username == null || username == "") && (faultID != null || faultID != "") && (dateFrom == null || dateFrom == "") && (dateTo == null || dateTo == ""))
                {
                    //WITH faultID

                    int fID = 0;

                    try
                    {
                        fID = Convert.ToInt32(faultID);
                    }
                    catch (Exception e)
                    {
                        TempData["Error"] = "No such fault ID was found.";
                        return RedirectToAction("Index", faultLogs);
                    }

                    if (new FaultClient().GetAllFaultLogsByFaultID(fID).ToList() != null)
                    {
                        faultLogList = new FaultClient().GetAllFaultLogsByFaultID(fID).ToList();
                    }
                    else
                    {
                        TempData["Error"] = "No such fault ID was found.";
                        return RedirectToAction("Index", faultLogs);
                    }
                }
                else if ((username == null || username == "") && (faultID == null || faultID == "") && (dateFrom != null || dateFrom != "") && (dateTo != null || dateTo != ""))
                {
                    //WITH DATES
                    try
                    {
                        DateTime from = Convert.ToDateTime(dateFrom);
                        DateTime to = Convert.ToDateTime(dateTo);

                        faultLogList = new FaultClient().GetFaultLogsByDate(from, to).ToList();
                    }
                    catch (Exception e)
                    {
                        TempData["Error"] = "Date format is incorrect.";
                        return RedirectToAction("Index", faultLogs);
                    }
                }
                else if ((username != null || !username.Equals("")) && (faultID != null || !faultID.Equals("")) && (dateFrom != null || !dateFrom.Equals("")) && (dateTo != null || !dateTo.Equals("")))
                {
                    //ALL COMBINATIONS

                    int fID = 0;

                    try
                    {
                        fID = Convert.ToInt32(faultID);
                    }
                    catch (Exception e)
                    {
                        TempData["Error"] = "No such fault ID was found.";
                        return RedirectToAction("Index", faultLogs);
                    }

                    if (new UserAccountClient().GetAccountByUsername(username) != null && new FaultClient().GetAllFaultLogsByFaultID(fID).ToList() != null)
                    {
                        DateTime from;
                        DateTime to;
                        try
                        {
                            from = Convert.ToDateTime(dateFrom);
                            to = Convert.ToDateTime(dateTo);
                        }
                        catch (Exception e)
                        {
                            TempData["Error"] = "Dates are not in the correct format.";
                            return RedirectToAction("Index", faultLogs);
                        }
                        int faID = Convert.ToInt32(faultID);

                        Account account = new UserAccountClient().GetAccountByUsername(username);

                        faultLogList = new FaultClient().GetFaultsByAllThreeCombinations(account.ID, faID, from, to).ToList();
                    }
                    else
                    {
                        TempData["Error"] = "Please enter correct data.";
                        return RedirectToAction("Index", faultLogs);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Search must be done by either all three options, by username, by faultID, or by date-from and date-to.  Please enter the correct choice.");
                }

                return View("Index", faultLogList);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Update(int faultID)
        {
            if (Session["accountID"] != null)
            {
                GenerateFaultModel model = new GenerateFaultModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public ActionResult Update(GenerateFaultModel model, int faultID)
        {
            try
            {
                if (Session["accountID"] != null)
                {
                    FaultLog faultLog = new FaultLog();

                    //faultLog.Status = model.Status;

                    int statusID = Convert.ToInt32(model.Status);
                    switch (statusID)
                    {
                        case 1:
                            faultLog.Status = "Reported";
                            sendSMS("Reported");
                            break;
                        case 2:
                            faultLog.Status = "Picked up - Transit to main office";
                            sendSMS("Picked up - Transit to main office");
                            break;
                        case 3:
                            faultLog.Status = "Service in progress";
                            sendSMS("Service in progress");
                            break;
                        case 4:
                            faultLog.Status = "Service completed - Ready for delivery";
                            sendSMS("Service completed - Ready for delivery");
                            break;
                        case 5:
                            faultLog.Status = "Picked up - Transit to customer";
                            sendSMS("Picked up - Transit to customer");
                            break;
                        case 6:
                            faultLog.Status = "Fault Completed";
                            sendSMS("Fault Completed");
                            break;
                        default:
                            faultLog.Status = "Reported";
                            sendSMS("Reported");
                            break;
                    }

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
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = "An error has occured.";
                return RedirectToAction("Index", faultLogs);
            }

        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Sort()
        {
            if (Session["accountID"] != null)
            {
                faultLogList = new FaultClient().sortByDateDesc().ToList();

                return View("Index", faultLogList);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public void sendSMS(string fault)
        {
            WebClient clientSMS = new WebClient();

            clientSMS.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            clientSMS.QueryString.Add("user", "ClaireG");
            clientSMS.QueryString.Add("password", "riku456");
            clientSMS.QueryString.Add("api_id", "3477985");
            clientSMS.QueryString.Add("to", "35699264547");

            clientSMS.QueryString.Add("text", "Fault updated, Current Status is: " + fault + "");
            string baseurl = "http://api.clickatell.com/http/sendmsg";
            Stream data = clientSMS.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string sms = reader.ReadToEnd();
            data.Close();
            reader.Close();

        }
    }
}
