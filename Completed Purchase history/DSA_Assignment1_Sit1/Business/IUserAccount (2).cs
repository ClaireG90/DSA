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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserAccount" in both code and config file together.
    [ServiceContract]
    public interface IUserAccount
    {
        /// <summary>
        /// Adds a user, user roles and an account to the database
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="roles">A list of role IDs</param>
        /// <param name="a">The account</param>
        [OperationContract]
        void AddUser(Common.User user, List<int> roles, Common.Account a);

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <returns>The user</returns>
        [OperationContract]
        User GetUserByID(int id);

        /// <summary>
        /// Gets an account by username
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>The account</returns>
        [OperationContract]
        Account GetAccountByUsername(string username);

        /// <summary>
        /// Gets user by email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>The user</returns>
        [OperationContract]
        User GetUserByEmail(string email);

        /// <summary>
        /// Gets all towns
        /// </summary>
        /// <returns>A list of towns</returns>
        [OperationContract]
        IEnumerable<Town> GetAllTowns();

        /// <summary>
        /// Gets all countries
        /// </summary>
        /// <returns>A list of countries</returns>
        [OperationContract]
        List<Common.Country> GetAllCountries();

        /// <summary>
        /// Gets all roles
        /// </summary>
        /// <returns>A list of roles</returns>
        [OperationContract]
        IEnumerable<Role> GetAllRoles();

        /// <summary>
        /// Gets all user accounts
        /// </summary>
        /// <returns>A list of user accounts</returns>
        [OperationContract]
        IEnumerable<Account> GetAllAccounts();

        /// <summary>
        /// Gets user by account ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <returns>The user</returns>
        [OperationContract]
        Common.User GetUserByAccountID(int aID);

        /// <summary>
        /// Gets user roles by username
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>A list of roles</returns>
        [OperationContract]
        IEnumerable<Role> GetUserRoles(string username);

        /// <summary>
        /// Gets account by PIN number
        /// </summary>
        /// <param name="pin">The PIN number</param>
        /// <returns>The account</returns>
        [OperationContract]
        Common.Account GetAccountByPIN(int pin);
    }
}
