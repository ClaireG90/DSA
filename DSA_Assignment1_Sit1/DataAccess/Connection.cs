using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class Connection
    {
        public Entitie entities;

        public Connection(Entitie entities)
        {
            this.entities = entities;
        }
        public Connection()
        {
            entities = new Entitie();
        }
    }
}
