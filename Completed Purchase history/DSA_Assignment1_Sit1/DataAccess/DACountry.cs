using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DACountry : Connection
    {
        public DACountry()
            :base()
        {}

        public DACountry(Entities entities)
            : base(entities)
        { }

        public IEnumerable<Country> GetAllCountries()
        {
            return entities.Country;
        }
    }
}
