using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAUser : Connection
    {
        public DAUser()
            : base()
        { }

        public DAUser(Entities entities)
            : base(entities)
        { }

        public IEnumerable<User> GetAllUsers()
        {
            return entities.User.AsEnumerable();
        }

        public User GetUserByID(int id)
        {
            return entities.User.SingleOrDefault(u => u.ID == id);
        }

        public User GetUserByEmail(string email)
        {
            return entities.User.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserByAccountID(int aID)
        {
            return entities.User.SingleOrDefault(u => u.AccountID == aID);
        }

        public void AddUser(User user)
        {
            entities.User.AddObject(user);
            entities.SaveChanges();
        }
    }
}
