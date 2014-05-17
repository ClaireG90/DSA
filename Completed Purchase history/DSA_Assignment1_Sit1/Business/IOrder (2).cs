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
        /// <summary>
        /// Gets order status by ID
        /// </summary>
        /// <param name="id">The order status ID</param>
        /// <returns>The order status</returns>
        [OperationContract]
        Common.OrderStatus GetOrderStatusByID(int id);

        /// <summary>
        /// Gets order status by name
        /// </summary>
        /// <param name="name">The status name</param>
        /// <returns>The order status</returns>
        [OperationContract]
        Common.OrderStatus GetOrderStatusByName(string name);

        /// <summary>
        /// Gets order by account ID and status ID
        /// </summary>
        /// <param name="aid">The account ID</param>
        /// <param name="sid">The statuc ID</param>
        /// <returns></returns>
        [OperationContract]
        Common.Order GetOrderByAccountAndStatus(int aid, int sid);
        
        /// <summary>
        /// Gets product order by order ID and product ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <param name="pID">The product ID</param>
        /// <returns>The product order</returns>
        [OperationContract]
        Common.ProductOrder GetProductOrderByOrderIDAndProductID(int oID, int pID);

        /// <summary>
        /// Gets product orders by order ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <returns>A list of product orders</returns>
        [OperationContract]
        List<Common.ProductOrder> GetProductOrderByOrderID(int oID);

        /// <summary>
        /// Updates a product order
        /// </summary>
        /// <param name="po">The product order</param>
        [OperationContract]
        void UpdateProductOrder(Common.ProductOrder po);

        /// <summary>
        /// Adds a new product order
        /// </summary>
        /// <param name="po">The product order</param>
        [OperationContract]
        void AddProductOrder(Common.ProductOrder po);

        /// <summary>
        /// Adds an order
        /// </summary>
        /// <param name="oder">The order</param>
        [OperationContract]
        void AddOrder(Common.Order oder);

        /// <summary>
        /// Gets order by ID
        /// </summary>
        /// <param name="id">The order ID</param>
        /// <returns>The order</returns>
        [OperationContract]
        Common.Order GetOrderByID(int id);

        /// <summary>
        /// Gets order by account ID
        /// </summary>
        /// <param name="aid">The account ID</param>
        /// <returns>A list of orders</returns>
        [OperationContract]
        IEnumerable<Common.Order> GetOrdersByAccountID(int aid);
        
        /// <summary>
        /// Gets checked out order by account ID
        /// </summary>
        /// <param name="aid">The account ID</param>
        /// <returns>A list of orders</returns>
        [OperationContract]
        List<Common.Order> GetBoughtOrdersByAccountID(int aid);

        /// <summary>
        /// Updates an order
        /// </summary>
        /// <param name="order">The order</param>
        [OperationContract]
        void UpdateOrder(Common.Order order);

        /// <summary>
        /// Deletes a product order by order ID and product ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <param name="pID">The product ID</param>
        [OperationContract]
        void DeleteProductOrder(int oID, int pID);

        /// <summary>
        /// Gets product orders which are still under warranty by order ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <returns>A list of product orders</returns>
        [OperationContract]
        List<Common.ProductOrder> GetWarrantyUnexpiredOrdersByOrderID(int oID);

        /// <summary>
        /// Gets orders by Account ID, date from, and date to
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="dateFrom">The date from</param>
        /// <param name="dateTo">The date to</param>
        /// <returns>A list of orders</returns>
        [OperationContract]
        List<Common.Order> getOrdersByAccountAndDates(int aID, DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// Gets order by date and account ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="date">The date</param>
        /// <returns>The order</returns>
        [OperationContract]
        Common.Order getOrderByDateAndAccount(int aID, DateTime date);
    }
}
