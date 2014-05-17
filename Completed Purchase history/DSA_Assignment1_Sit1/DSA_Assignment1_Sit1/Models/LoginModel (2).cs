using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSA_Assignment1_Sit1.UserAccountServ;
using System.ComponentModel.DataAnnotations;

namespace DSA_Assignment1_Sit1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage= "This field is required.")]
        public string username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string token { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int pin { get; set; }

    }
}