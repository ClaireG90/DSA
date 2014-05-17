using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.ComponentModel.DataAnnotations;

namespace DSA_Assignment1_Sit1.Models
{
    public class UpdateFaultStatusModel
    {
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

        [Required (ErrorMessage="Fault Description is required.")]
        public string Description { get; set; }


    }
}