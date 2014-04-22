using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace DSA_Assignment1_Sit1.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string commnet { get; set; }
        public int ProductID { get; set; }
        public int aID { get; set; }

        public virtual Product myProduct { get; set; }

        public CommentModel()
        {
        }

    }
}