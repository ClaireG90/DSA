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
    public class ShoppingCartModel
    {
        public Order order { get; set; }
        public List<ProductOrder> productOrders { get; set; }
        public List<Product> productList { get; set; }
    }
}
