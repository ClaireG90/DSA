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
            if (model.Password.ToString().Length < 6)
            {
                ViewBag.Message = "Password length must be at least 6 characters.";
            }
            else if (new UserAccountServ.UserAccountClient().GetAccountByUsername(model.Username.ToString()) != null)
            {
                ModelState.AddModelError("", "Username taken.");
                ViewBag.Message = "Username already taken.";
            }
            else if (new UserAccountServ.UserAccountClient().GetUserByEmail(model.Email.ToString()) != null)
            {
                ModelState.AddModelError("", "Email taken.");
                ViewBag.Message = "Email already taken.";
            }
            else if (new UserAccountServ.UserAccountClient().GetAccountByPIN(model.PIN) != null)
            {
                ModelState.AddModelError("", "PIN taken.");
                ViewBag.Message = "PIN already taken.";
            }
            else
            {
                Account acc = new UserAccountServ.UserAccountClient().GetAccountByUsername(model.Username);
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

                User u = new User();
                u.Name = model.Name;
                u.Surname = model.Surname;
                u.Email = model.Email;
                u.Mobile = model.Mobile;
                u.ResidenceName = model.ResidenceName;
                u.StreetName = model.StreetName;

                Account a = new Account();
                a.Username = model.Username;
                a.Password = model.Password;
                a.PIN = model.PIN;

                new UserAccountServ.UserAccountClient().AddUser(u, arraylist, a);

                UtilitiesApplication.Encryption encrytion = new UtilitiesApplication.Encryption();
                ViewBag.Token = "Your token is  " + encrytion.EncryptTripleDES(model.Password.ToString(), model.PIN.ToString()) + "  Please use this to log in.";


            }
            
            return View(model);
        }
    }
}
