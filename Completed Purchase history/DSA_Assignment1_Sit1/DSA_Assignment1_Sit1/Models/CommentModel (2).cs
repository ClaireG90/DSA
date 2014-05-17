using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.ComponentModel.DataAnnotations;

namespace DSA_Assignment1_Sit1.Models
{
    public class CommentModel
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "Please enter a comment.")]
        public string commnet { get; set; }

        public int ProductID { get; set; }
        public int aID { get; set; }

        [Range(1, 5)]
        public int rating { get; set; }

        public virtual Product myProduct { get; set; }

        public CommentModel()
        {
        }

    }
}