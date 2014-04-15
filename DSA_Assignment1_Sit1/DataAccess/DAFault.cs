using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAFault : Connection
    {
        public DAFault()
            : base()
        { }

        public DAFault(Entities entities)
            : base(entities)
        { }

        public Fault GetFaultByID(int id)
        {
            return entities.Fault.SingleOrDefault(f => f.ID == id);
        }

        public IEnumerable<Fault> GetAllFaults()
        {
            return entities.Fault.AsEnumerable();
        }

        public void AddFault(Fault fault)
        {
            entities.Fault.AddObject(fault);
            entities.SaveChanges();
        }

        public Fault GetFaultByTicketNumber(int num)
        {
            return entities.Fault.SingleOrDefault(f => f.TicketNumber == num);
        }

        public IEnumerable<Fault> GetFaultsByAccountID(int aID)
        {
            return entities.Fault.Where(f => f.AccountID == aID);
        }
    }
}