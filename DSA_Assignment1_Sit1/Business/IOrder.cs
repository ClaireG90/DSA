using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrder" in both code and config file together.
    [ServiceContract]
    public interface IOrder
    {
        [OperationContract]
        Common.OrderStatus GetOrderStatusByID(int id);

        [OperationContract]
        Common.OrderStatus GetOrderStatusByName(string name);

        [OperationContract]
        Common.Order GetOrderByAccountAndStatus(int aid, int sid);

        [OperationContract]
        Common.ProductOrder GetProductOrderByOrderIDAndProductID(int oID, int pID);

        [OperationContract]
        void UpdateProductOrder(Common.ProductOrder po);

        [OperationContract]
        void AddProductOrder(Common.ProductOrder po);

        [OperationContract]
        void AddOrder(Common.Order oder);

        [OperationContract]
        Common.Order GetOrderByID(int id);

        [OperationContract]
        IEnumerable<Common.Order> GetOrdersByAccountID(int aid);
    }
}
