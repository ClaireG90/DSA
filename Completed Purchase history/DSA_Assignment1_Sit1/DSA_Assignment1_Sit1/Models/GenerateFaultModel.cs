using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Drawing;

namespace DSA_Assignment1_Sit1.Models
{
    public class GenerateFaultModel
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime DateOfReport { get; set; }

        public Product myProduct { get; set; }
        public Image image { get; set; }
    }
}