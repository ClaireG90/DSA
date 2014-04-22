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
        public List<Common.Fault> GetAllFaults()
        {
            return new DAFault().GetAllFaults().ToList();
        }

        public List<Common.FaultLog> GetAllFaultLogs()
        {
            return new DAFaultLog().GetAllFaultLogs().ToList();
        }

        public List<FaultLog> GetAllFaultLogsByFaultID(int id)
        {
            return new DAFaultLog().GetAllFaultLogsByFaultID(id).ToList();
        }

        public void AddFault(Common.Fault fault)
        {
            new DAFault().AddFault(fault);
        }

        public void AddFaultLog(FaultLog faultLog)
        {
            new DAFaultLog().AddFaultLog(faultLog);
        }

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

        public Common.Fault GetFaultByTicketNumber(int num)
        {
            return new DAFault().GetFaultByTicketNumber(num);
        }

        public List<Common.Fault> GetFaultsByAccountID(int aID)
        {
            return new DAFault().GetFaultsByAccountID(aID).ToList();
        }

        public Common.Fault GetFaultByID(int id)
        {
            return new DAFault().GetFaultByID(id);
        }

        public List<Common.FaultLog> GetFaultLogsByDate(DateTime from, DateTime to)
        {
            return new DAFaultLog().GetFaultLogsByDate(from, to).ToList();
        }

        public List<FaultLog> GetFaultsByAllThreeCombinations(int aID, int fID, DateTime fromdate, DateTime todate)
        {
            return new DAFaultLog().GetFaultsByAllThreeCombinations(aID, fID, fromdate, todate).ToList();
        }

        public List<Common.Fault> GetFaultsByAccountIDandProductID(int aID, int pID)
        {
            return new DAFault().GetFaultsByAccountIDandProductID(aID, pID).ToList();
        }

        public List<FaultLog> sortByDateAsc()
        {
            return new DAFaultLog().sortByDateAsc().ToList();
        }

        public List<FaultLog> sortByDateDesc()
        {
            return new DAFaultLog().sortByDateDesc().ToList();
        }
    }
}
