using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DSA_Assignment1_Sit1.Models;
using UtilitiesApplication;


namespace DSA_Assignment1_Sit1.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View(new Models.RegistrationModel());
        }

        [HttpPost]
        public ActionResult CreateUser(RegistrationModel model)
        {
            if(string.IsNullOrEmpty(model.user.Name.ToString()))
            {
                ModelState.AddModelError("", "Please enter your name.");
            }
            else if (string.IsNullOrEmpty(model.user.Surname.ToString()))
            {
                ModelState.AddModelError("", "Please enter your surname.");
            }
            else if (string.IsNullOrEmpty(model.user.Email.ToString()))
            {
                ModelState.AddModelError("", "Please enter your email.");
            }
            else if (string.IsNullOrEmpty(model.user.Mobile.ToString()))
            {
                ModelState.AddModelError("", "Please enter your mobile.");
            }
            else if (string.IsNullOrEmpty(model.user.ResidenceName.ToString()))
            {
                ModelState.AddModelError("", "Please enter your residence name.");
            }
            else if (string.IsNullOrEmpty(model.user.StreetName.ToString()))
            {
                ModelState.AddModelError("", "Please enter your street name.");
            }
            else if (string.IsNullOrEmpty(model.account.Username.ToString()))
            {
                ModelState.AddModelError("", "Please enter a username.");
            }
            else if (string.IsNullOrEmpty(model.account.Password.ToString()))
            {
                ModelState.AddModelError("", "Please enter a password.");
            }
            else if (string.IsNullOrEmpty(model.account.PIN.ToString()))
            {
                ModelState.AddModelError("", "Please enter a PIN number.");
            }
            else if (model.account.Password.ToString().Length < 6)
            {
                ModelState.AddModelError("", "Password length must be at least 6 characters.");
            }
            else if (model.account.PIN.ToString().Length < 4 || model.account.PIN.ToString().Length > 4)
            {
                ModelState.AddModelError("", "PIN must be 4 digits long.");
            }
            else if (new UserAccountServ.UserAccountClient().GetAccountByUsername(model.account.Username.ToString()) != null)
            {
                ModelState.AddModelError("", "Username taken.");
                ViewBag.Message = "Username already taken.";
            }
            else if (new UserAccountServ.UserAccountClient().GetUserByEmail(model.user.Email.ToString()) != null)
            {
                ModelState.AddModelError("", "Email taken.");
                ViewBag.Message = "Email already taken.";
            }
            else if (ModelState.IsValid)
            {
                Account acc = new UserAccountServ.UserAccountClient().GetAccountByUsername(model.account.Username);
                int roleID = 0;
                List<int> add = new List<int>();

                for (int i = 0; i < model.roles.Count; i++)
                {
                    if (model.checkboxes[i].Checked)
                    {
                        roleID = model.roles[i].ID;
                        add.Add(roleID);
                    }
                }
                int[] arraylist = add.ToArray();

                
 
                new UserAccountServ.UserAccountClient().AddUser(model.user, arraylist, model.account);

                UtilitiesApplication.Encryption encrytion = new UtilitiesApplication.Encryption();
                ViewBag.Token = "Your token is  " + encrytion.EncryptTripleDES(model.account.Password.ToString(), model.account.PIN.ToString()) + "  Please use this to log in.";
               // return RedirectToAction("CreateUser");

                
            }
            
            return View(model);
        }
    }
}
