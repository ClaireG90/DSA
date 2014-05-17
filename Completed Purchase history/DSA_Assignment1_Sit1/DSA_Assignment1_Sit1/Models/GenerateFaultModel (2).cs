using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace DSA_Assignment1_Sit1.Models
{
    public class GenerateFaultModel
    {
        //public string Status { get; set; }

        public int StatusID { get; set; }
        public string Status { get; set; }

        public IEnumerable<UpdateFaultStatusModel> GetStatus()
        {
            return new List<UpdateFaultStatusModel>
            {
                new UpdateFaultStatusModel() {StatusID = 1, Status = "Reported"},
                new UpdateFaultStatusModel() {StatusID = 2, Status = "Picked up - Transit to main office"},
                new UpdateFaultStatusModel() {StatusID = 3, Status = "Service in progress"},
                new UpdateFaultStatusModel() {StatusID = 4, Status = "Service completed - Ready for delivery"},
                new UpdateFaultStatusModel() {StatusID = 5, Status = "Picked up - Transit to customer"},
                new UpdateFaultStatusModel() {StatusID = 6, Status = "Fault Completed"}
            };
        }

        [Required (ErrorMessage="Please decribe the problem.")]
        public string Description { get; set; }

        public DateTime DateOfReport { get; set; }

        public Product myProduct { get; set; }
        public Image image { get; set; }
    }
}