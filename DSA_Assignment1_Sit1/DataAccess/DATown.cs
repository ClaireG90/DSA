﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DATown : Connection
    {
        public DATown()
            : base()
        { }

        public IEnumerable<Town> GetAllTowns()
        {
            return entities.Town.AsEnumerable();
        }

        public Town GetTownByID(int id)
        {
            return entities.Town.SingleOrDefault(t => t.ID == id);
        }
    }
}
