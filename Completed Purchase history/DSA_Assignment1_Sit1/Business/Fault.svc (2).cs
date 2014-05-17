using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using DataAccess;
using System.Collections;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Fault" in code, svc and config file together.
    public class Fault : IFault
    {
        /// <summary>
        /// Gets all the faults
        /// </summary>
        /// <returns>A list with all the faults</returns>
        public List<Common.Fault> GetAllFaults()
        {
            return new DAFault().GetAllFaults().ToList();
        }

        /// <summary>
        /// Gets all the fault logs
        /// </summary>
        /// <returns>A list with all the fault logs</returns>
        public List<Common.FaultLog> GetAllFaultLogs()
        {
            return new DAFaultLog().GetAllFaultLogs().ToList();
        }

        /// <summary>
        /// Gets all fault logs which contain a specific fault ID 
        /// </summary>
        /// <param name="id">The fault ID</param>
        /// <returns>A list with the fault logs</returns>
        public List<FaultLog> GetAllFaultLogsByFaultID(int id)
        {
            return new DAFaultLog().GetAllFaultLogsByFaultID(id).ToList();
        }

        /// <summary>
        /// Adds a fault to the database
        /// </summary>
        /// <param name="fault">The fault to add</param>
        public void AddFault(Common.Fault fault)
        {
            new DAFault().AddFault(fault);
        }

        /// <summary>
        /// Adds a fault log to the database
        /// </summary>
        /// <param name="faultLog">The fault log to add</param>
        public void AddFaultLog(FaultLog faultLog)
        {
            new DAFaultLog().AddFaultLog(faultLog);
        }

        /// <summary>
        /// Generates a six-digit random number
        /// </summary>
        /// <returns>The randomly generated number</returns>
        public int GenerateRandomNumber()
        {
            Random r = new Random();
            string stringNum = "";
            int i;
            for (i = 1; i < 7; i++)
            {
                stringNum += r.Next(0, 9).ToString();
            }
            return Convert.ToInt32(stringNum);
        }

        /// <summary>
        /// Gets a fault which contains a ticketnumber
        /// </summary>
        /// <param name="num">The ticket number</param>
        /// <returns>The fault</returns>
        public Common.Fault GetFaultByTicketNumber(int num)
        {
            return new DAFault().GetFaultByTicketNumber(num);
        }

        /// <summary>
        /// Gets faults which contain an account ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <returns>A list of faults</returns>
        public List<Common.Fault> GetFaultsByAccountID(int aID)
        {
            return new DAFault().GetFaultsByAccountID(aID).ToList();
        }

        /// <summary>
        /// Gets a fault by its ID
        /// </summary>
        /// <param name="id">The fault ID</param>
        /// <returns>The fault</returns>
        public Common.Fault GetFaultByID(int id)
        {
            return new DAFault().GetFaultByID(id);
        }

        /// <summary>
        /// Gets faults between two given dates
        /// </summary>
        /// <param name="from">The date from</param>
        /// <param name="to">The date to</param>
        /// <returns>A list of faults</returns>
        public List<Common.FaultLog> GetFaultLogsByDate(DateTime from, DateTime to)
        {
            return new DAFaultLog().GetFaultLogsByDate(from, to).ToList();
        }

        /// <summary>
        /// Gets fault logs which contain three different attributes; account ID, fault ID, date from, and date to
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="fID">The fault ID</param>
        /// <param name="fromdate">The date from</param>
        /// <param name="todate">The date to</param>
        /// <returnsA list of fault logs></returns>
        public List<FaultLog> GetFaultsByAllThreeCombinations(int aID, int fID, DateTime fromdate, DateTime todate)
        {
            return new DAFaultLog().GetFaultsByAllThreeCombinations(aID, fID, fromdate, todate).ToList();
        }

        /// <summary>
        /// Gets faults by account ID and product ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="pID">The product ID</param>
        /// <returns>A list of faults</returns>
        public List<Common.Fault> GetFaultsByAccountIDandProductID(int aID, int pID)
        {
            return new DAFault().GetFaultsByAccountIDandProductID(aID, pID).ToList();
        }

        /// <summary>
        /// Retrieves fault logs sorted by the date reported in ascending order
        /// </summary>
        /// <returns>A list of fault logs</returns>
        public List<FaultLog> sortByDateAsc()
        {
            return new DAFaultLog().sortByDateAsc().ToList();
        }

        /// <summary>
        /// Retrieves fault logs sorted by the date reported in descending order
        /// </summary>
        /// <returns>A list of fault logs</returns>
        public List<FaultLog> sortByDateDesc()
        {
            return new DAFaultLog().sortByDateDesc().ToList();
        }
    }
}
