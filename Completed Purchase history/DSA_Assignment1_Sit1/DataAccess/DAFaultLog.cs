using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Collections;

namespace DataAccess
{
    public class DAFaultLog : Connection
    {
        public DAFaultLog()
            : base()
        { }

        public DAFaultLog(Entities entities)
            : base(entities)
        { }

        public IEnumerable<FaultLog> GetAllFaultLogs()
        {
            return entities.FaultLog;
        }

        public IEnumerable<FaultLog> GetAllFaultLogsByFaultID(int id)
        {
            return entities.FaultLog.Where(f => f.FaultID == id);
        }

        public IEnumerable<FaultLog> GetFaultLogsByDate(DateTime from, DateTime to)
        {
            return entities.FaultLog.Where(f => f.DateOfReport >= from && f.DateOfReport <= to);
        }

        public void AddFaultLog(FaultLog faultLog)
        {
            entities.FaultLog.AddObject(faultLog);
            entities.SaveChanges();
        }

        public IEnumerable<FaultLog> GetFaultsByAllThreeCombinations(int aID, int fID, DateTime fromdate, DateTime todate)
        { 
            Fault f = new DAFault().GetFaultByID(fID);
            return entities.FaultLog.Where(fl => fl.FaultID == fID && f.AccountID == aID && fl.DateOfReport >= fromdate && fl.DateOfReport <= todate).ToList();
        }

        public IEnumerable<FaultLog> sortByDateAsc()
        {
            return entities.FaultLog.OrderBy(f => f.DateOfReport);
        }

        public IEnumerable<FaultLog> sortByDateDesc()
        {
            return entities.FaultLog.OrderByDescending(f => f.DateOfReport);
        }
    }
}
