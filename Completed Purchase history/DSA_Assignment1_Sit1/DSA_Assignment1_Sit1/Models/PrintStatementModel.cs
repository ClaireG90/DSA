using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace DSA_Assignment1_Sit1.Models
{
    public class PrintStatementModel
    {
        public Product myProduct { get; set; }
        public List<Fault> myFaultList { get; set; }
        public List<FaultLog> myFaultLog { get; set; }
        public Order myOrder { get; set; }
        public ProductOrder myProductOrder { get; set; }
        public Fault myFault { get; set; }

        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
    }
}