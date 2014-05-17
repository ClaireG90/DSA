using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DACategory : Connection
    {
        public DACategory()
            : base()
        { }

        public Category getCategoryByName(string name)
        {
            return entities.Category.SingleOrDefault(c => c.Name.Contains(name));
        }
    }
}
