using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

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

        public void AddFaultLog(FaultLog faultLog)
        {
            entities.FaultLog.AddObject(faultLog);
            entities.SaveChanges();
        }

    }
}
