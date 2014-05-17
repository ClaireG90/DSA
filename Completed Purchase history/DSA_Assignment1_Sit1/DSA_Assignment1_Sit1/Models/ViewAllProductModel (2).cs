using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Web.Mvc;
using DSA_Assignment1_Sit1.ProductServ;
using DSA_Assignment1_Sit1.ProductCommentServ;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace DSA_Assignment1_Sit1.Models
{
    public class ViewAllProductModel
    {
        //public Product product { get; set; }
        public int ID { get; set; }
        public string name { get; set; }
        public string features { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
        public DateTime dateListed { get; set; }

        [Required (ErrorMessage= "Please enter the quantity you wish to buy")]
        [Range(1, 100)]
        public int quantity { get; set; }

        public double rating { get; set; }

        public Product myProduct{get;set;}

        public List<Comment> commentList { get; set; }

    }
}