using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Web.Mvc;
using DSA_Assignment1_Sit1.UserAccountServ;
using System.ComponentModel.DataAnnotations;

namespace DSA_Assignment1_Sit1.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ResidenceName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Mobile { get; set; }

        //Account
        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN is not valid")]
        public int PIN { get; set; }


        public User user { get; set; }

        public Account account { get; set; }

        public SelectList townList { get; set; }

        public SelectList countryList { get; set; }

        public List<Role> roles { get; set; }
        
        public List<CheckBoxes> checkboxes { get; set; }

        public class CheckBoxes
        {
            public bool Checked { get; set; }
        }

        public RegistrationModel()
        {
            List<bool> myList = new List<bool>();
            myList.Add(true);
            myList.Add(false);

            roles = new List<Role>(new UserAccountClient().GetAllRoles());
            townList = new SelectList(new UserAccountClient().GetAllTowns(), "ID", "Name");
            countryList = new SelectList(new UserAccountClient().GetAllCountries(), "ID", "Name");
        }
    }
}