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
        [Required]
        public User user { get; set; }

        [Required]
        public Account account { get; set; }

        [Required]
        public SelectList townList { get; set; }

        [Required]
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
        }
    }
}