using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DSA_Assignment1_Sit1.UserAccountServ;
using DSA_Assignment1_Sit1.Models;
using UtilitiesApplication;
using System.Web.Security;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new Models.LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            UtilitiesApplication.Encryption encryption = new UtilitiesApplication.Encryption();

            if (new UserAccountServ.UserAccountClient().GetAccountByUsername(model.username) != null)
            {
                Account account = new UserAccountServ.UserAccountClient().GetAccountByUsername(model.username);

                if (encryption.EncryptTripleDES(account.Password.ToString(), account.PIN.ToString()) != model.token)
                {
                    ModelState.AddModelError("", "Token is not valid.");
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(model.username, true);
                    Session["accountID"] = account.ID;

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Username does not exist.");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout(LoginModel model)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
