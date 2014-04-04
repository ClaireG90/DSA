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
        [OperationContract]
        void AddUser(Common.User user, List<int> roles, Common.Account a);

        [OperationContract]
        User GetUserByID(int id);

        [OperationContract]
        Account GetAccountByUsername(string username);

        [OperationContract]
        User GetUserByEmail(string email);

        [OperationContract]
        IEnumerable<Town> GetAllTowns();

        [OperationContract]
        IEnumerable<Role> GetAllRoles();

        [OperationContract]
        IEnumerable<Account> GetAllAccounts();
    }
}
