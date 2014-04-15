using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using DataAccess;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserAccount" in code, svc and config file together.
    public class UserAccount : IUserAccount
    {
        Entities entities = new Entities();

        public void AddUser(Common.User u, List<int> roles, Common.Account a)
        {
            foreach (int role in roles)
            {
                Role r = new DARole(entities).GetRoleByID(role);
                a.Role.Add(r);
            }

            Account ac = this.GetAccountByUsername(a.Username);
            new DAUser(this.entities).AddUser(u);
        }

        public User GetUserByID(int id)
        {
            return new DAUser().GetUserByID(id);
        }

        public Account GetAccountByUsername(string username)
        {
            return new DAAccount().GetAccountByUsername(username);
        }

        public IEnumerable<Town> GetAllTowns()
        {
            return new DATown().GetAllTowns();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return new DARole().GetAllRoles();
        }

        public User GetUserByEmail(string email)
        {
            return new DAUser().GetUserByEmail(email);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return new DAAccount().GetAllAccounts();
        }

        public User GetUserByAccountID(int aID)
        {
            return new DAUser().GetUserByAccountID(aID);
        }
    }
}
