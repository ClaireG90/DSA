using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using System.Collections;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFault" in both code and config file together.
    [ServiceContract]
    public interface IFault
    {
        /// <summary>
        /// Gets all the faults
        /// </summary>
        /// <returns>A list with all the faults</returns>
        [OperationContract]
        List<Common.Fault> GetAllFaults();

        /// <summary>
        /// Gets all the fault logs
        /// </summary>
        /// <returns>A list with all the fault logs</returns>
        [OperationContract]
        List<Common.FaultLog> GetAllFaultLogs();

        /// <summary>
        /// Gets all fault logs which contain a specific fault ID 
        /// </summary>
        /// <param name="id">The fault ID</param>
        /// <returns>A list with the fault logs</returns>
        [OperationContract]
        List<Common.FaultLog> GetAllFaultLogsByFaultID(int id);

        /// <summary>
        /// Adds a fault to the database
        /// </summary>
        /// <param name="fault">The fault to add</param>
        [OperationContract]
        void AddFault(Common.Fault fault);

        /// <summary>
        /// Adds a fault log to the database
        /// </summary>
        /// <param name="faultLog">The fault log to add</param>
        [OperationContract]
        void AddFaultLog(Common.FaultLog faultLog);

        /// <summary>
        /// Generates a six-digit random number
        /// </summary>
        /// <returns>The randomly generated number</returns>
        [OperationContract]
        int GenerateRandomNumber();

        /// <summary>
        /// Gets a fault which contains a ticketnumber
        /// </summary>
        /// <param name="num">The ticket number</param>
        /// <returns>The fault</returns>
        [OperationContract]
        Common.Fault GetFaultByTicketNumber(int num);

        /// <summary>
        /// Gets faults which contain an account ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <returns>A list of faults</returns>
        [OperationContract]
        List<Common.Fault> GetFaultsByAccountID(int aID);

        /// <summary>
        /// Gets a fault by its ID
        /// </summary>
        /// <param name="id">The fault ID</param>
        /// <returns>The fault</returns>
        [OperationContract]
        Common.Fault GetFaultByID(int id);

        /// <summary>
        /// Gets faults between two given dates
        /// </summary>
        /// <param name="from">The date from</param>
        /// <param name="to">The date to</param>
        /// <returns>A list of faults</returns>
        [OperationContract]
        List<Common.FaultLog> GetFaultLogsByDate(DateTime from, DateTime to);

        /// <summary>
        /// Gets fault logs which contain three different attributes; account ID, fault ID, date from, and date to
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="fID">The fault ID</param>
        /// <param name="fromdate">The date from</param>
        /// <param name="todate">The date to</param>
        /// <returnsA list of fault logs></returns>
        [OperationContract]
        List<Common.FaultLog> GetFaultsByAllThreeCombinations(int aID, int fID, DateTime fromdate, DateTime todate);

        /// <summary>
        /// Gets faults by account ID and product ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="pID">The product ID</param>
        /// <returns>A list of faults</returns>
        [OperationContract]
        List<Common.Fault> GetFaultsByAccountIDandProductID(int aID, int pID);

        /// <summary>
        /// Retrieves fault logs sorted by the date reported in ascending order
        /// </summary>
        /// <returns>A list of fault logs</returns>
        [OperationContract]
        List<Common.FaultLog> sortByDateAsc();

        /// <summary>
        /// Retrieves fault logs sorted by the date reported in descending order
        /// </summary>
        /// <returns>A list of fault logs</returns>
        [OperationContract]
        List<Common.FaultLog> sortByDateDesc();
    }
}
