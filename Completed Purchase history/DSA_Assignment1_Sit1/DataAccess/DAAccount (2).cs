using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAAccount : Connection
    {
        public DAAccount()
            : base()
        { }

        public IEnumerable<Account> GetAllAccounts()
        {
            return entities.Account.AsEnumerable();
        }

        public Account GetAccountByUsername(string username)
        {
            return entities.Account.SingleOrDefault(a => a.Username == username);
        }

        public void AddAccount(Account a)
        {
            entities.Account.AddObject(a);
            entities.SaveChanges();
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            return new DAAccount().GetAccountByUsername(username).Role.AsQueryable();
        }

        public Account GetAccountByPIN(int pin)
        {
            return entities.Account.SingleOrDefault(a => a.PIN == pin);
        }
    }
}
