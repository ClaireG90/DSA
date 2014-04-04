using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DARole : Connection
    {
        public DARole()
            : base()
        { }

        public DARole(Entitie entities)
            : base(entities)
        { }

        public Role GetRoleByID(int id)
        {
            return entities.Role.SingleOrDefault(r => r.ID == id);
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return entities.Role.AsEnumerable();
        }
    }
}
