using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class Connection
    {
        public Entities entities;

        public Connection(Entities entities)
        {
            this.entities = entities;
        }
        public Connection()
        {
            entities = new Entities();
        }
    }
}
