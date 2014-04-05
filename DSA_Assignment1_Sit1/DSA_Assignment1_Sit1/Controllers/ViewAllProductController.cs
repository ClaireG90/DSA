using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Web.Mvc;
using DSA_Assignment1_Sit1.ProductServ;
using DSA_Assignment1_Sit1.ProductCommentServ;
using System.ComponentModel.DataAnnotations;
using DSA_Assignment1_Sit1.Models;

namespace DSA_Assignment1_Sit1.Controllers
{
    public class ViewAllProductController : Controller
    {
        //
        // GET: /ViewAllProduct/

        public ActionResult Index()
        {
            List<Product> productList = new ProductClient().GetAllProducts().ToList();
            return View("Index", productList);
        }

        //public ActionResult Details(int id)
        //{
        //    List<Comment> commentList = new ProductCommentClient().GetCommentsByProductID(id).ToList;
        //    return View("Details", commentList);
        //}

        public ActionResult Details(int id)
        {
            return View(new ProductClient().GetProductByID(id));
        }

        public PartialViewResult ProductComments(int id)
        {
            List<Comment> commentList = new ProductCommentClient().GetCommentsByProductID(id).ToList();
            return PartialView("_comments", commentList);
        }
    }
}
