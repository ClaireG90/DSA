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

        /// <summary>
        /// Adds a user, user roles and an account to the database
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="roles">A list of role IDs</param>
        /// <param name="a">The account</param>
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

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <returns>The user</returns>
        public User GetUserByID(int id)
        {
            return new DAUser().GetUserByID(id);
        }

        /// <summary>
        /// Gets an account by username
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>The account</returns>
        public Account GetAccountByUsername(string username)
        {
            return new DAAccount().GetAccountByUsername(username);
        }

        /// <summary>
        /// Gets all towns
        /// </summary>
        /// <returns>A list of towns</returns>
        public IEnumerable<Town> GetAllTowns()
        {
            return new DATown().GetAllTowns();
        }

        /// <summary>
        /// Gets all countries
        /// </summary>
        /// <returns>A list of countries</returns>
        public List<Common.Country> GetAllCountries()
        {
            return new DACountry().GetAllCountries().ToList();
        }

        /// <summary>
        /// Gets all roles
        /// </summary>
        /// <returns>A list of roles</returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return new DARole().GetAllRoles();
        }

        /// <summary>
        /// Gets user by email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>The user</returns>
        public User GetUserByEmail(string email)
        {
            return new DAUser().GetUserByEmail(email);
        }

        /// <summary>
        /// Gets all user accounts
        /// </summary>
        /// <returns>A list of user accounts</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return new DAAccount().GetAllAccounts();
        }

        /// <summary>
        /// Gets user by account ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <returns>The user</returns>
        public User GetUserByAccountID(int aID)
        {
            return new DAUser().GetUserByAccountID(aID);
        }

        /// <summary>
        /// Gets user roles by username
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>A list of roles</returns>
        public IEnumerable<Role> GetUserRoles(string username)
        {
            return new DAAccount().GetUserRoles(username);
        }

        /// <summary>
        /// Gets account by PIN number
        /// </summary>
        /// <param name="pin">The PIN number</param>
        /// <returns>The account</returns>
        public Common.Account GetAccountByPIN(int pin)
        {
            return new DAAccount().GetAccountByPIN(pin);
        }
    }
}
