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
        [Required]
        public string username { get; set; }

        [Required]
        public string token { get; set; }

    }
}