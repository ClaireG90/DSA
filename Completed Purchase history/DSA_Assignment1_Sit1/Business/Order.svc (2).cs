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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Order" in code, svc and config file together.
    public class Order : IOrder
    {
        /// <summary>
        /// Gets order status by ID
        /// </summary>
        /// <param name="id">The order status ID</param>
        /// <returns>The order status</returns>
        public Common.OrderStatus GetOrderStatusByID(int id)
        {
            return new DAOrderStatus().GetOrderStatusByID(id);
        }

        /// <summary>
        /// Gets order status by name
        /// </summary>
        /// <param name="name">The status name</param>
        /// <returns>The order status</returns>
        public Common.OrderStatus GetOrderStatusByName(string name)
        {
            return new DAOrderStatus().GetOrderStatusByName(name);
        }

        /// <summary>
        /// Gets order by account ID and status ID
        /// </summary>
        /// <param name="aid">The account ID</param>
        /// <param name="sid">The statuc ID</param>
        /// <returns></returns>
        public Common.Order GetOrderByAccountAndStatus(int aid, int sid)
        {
            return new DAOrder().GetOrderByAccountAndStatus(aid, sid);
        }

        /// <summary>
        /// Gets product order by order ID and product ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <param name="pID">The product ID</param>
        /// <returns>The product order</returns>
        public void AddProductOrder(Common.ProductOrder po)
        {
            new DAProductOrder().AddProductOrder(po);
        }

        /// <summary>
        /// Adds an order
        /// </summary>
        /// <param name="oder">The order</param>
        public void AddOrder(Common.Order order)
        {
            new DAOrder().AddOrder(order);
        }

        /// <summary>
        /// Gets order by ID
        /// </summary>
        /// <param name="id">The order ID</param>
        /// <returns>The order</returns>
        public Common.Order GetOrderByID(int id)
        {
            return new DAOrder().GetOrderByID(id);
        }

        /// <summary>
        /// Gets order by account ID
        /// </summary>
        /// <param name="aid">The account ID</param>
        /// <returns>A list of orders</returns>
        public IEnumerable<Common.Order> GetOrdersByAccountID(int aid)
        {
            return new DAOrder().GetOrdersByAccountID(aid);
        }

        /// <summary>
        /// Gets product order by order ID and product ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <param name="pID">The product ID</param>
        /// <returns>The product order</returns>
        public Common.ProductOrder GetProductOrderByOrderIDAndProductID(int oID, int pID)
        {
            return new DAProductOrder().GetProductOrderByOrderIDAndProductID(oID, pID);
        }

        /// <summary>
        /// Gets product orders by order ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <returns>A list of product orders</returns>
        public List<Common.ProductOrder> GetProductOrderByOrderID(int oID)
        {
            return new DAProductOrder().GetProductOrderByOrderID(oID).ToList();
        }

        /// <summary>
        /// Updates a product order
        /// </summary>
        /// <param name="po">The product order</param>
        public void UpdateProductOrder(Common.ProductOrder po)
        {
            new DAProductOrder().UpdateProductOrder(po);
        }

        /// <summary>
        /// Gets checked out order by account ID
        /// </summary>
        /// <param name="aid">The account ID</param>
        /// <returns>A list of orders</returns>
        public List<Common.Order> GetBoughtOrdersByAccountID(int aid)
        {
            return new DAOrder().GetBoughtOrdersByAccountID(aid).ToList();
        }

        /// <summary>
        /// Updates an order
        /// </summary>
        /// <param name="order">The order</param>
        public void UpdateOrder(Common.Order order)
        {
            new DAOrder().UpdateOrder(order);
        }

        /// <summary>
        /// Deletes a product order by order ID and product ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <param name="pID">The product ID</param>
        public void DeleteProductOrder(int oID, int pID)
        {
            new DAProductOrder().DeleteProductOrder(oID, pID);
        }

        /// <summary>
        /// Gets product orders which are still under warranty by order ID
        /// </summary>
        /// <param name="oID">The order ID</param>
        /// <returns>A list of product orders</returns>
        public List<Common.ProductOrder> GetWarrantyUnexpiredOrdersByOrderID(int oID)
        {
            return new DAProductOrder().GetWarrantyUnexpiredOrdersByOrderID(oID).ToList();
        }

        /// <summary>
        /// Gets orders by Account ID, date from, and date to
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="dateFrom">The date from</param>
        /// <param name="dateTo">The date to</param>
        /// <returns>A list of orders</returns>
        public List<Common.Order> getOrdersByAccountAndDates(int aID, DateTime dateFrom, DateTime dateTo)
        {
            return new DAOrder().getOrdersByAccountAndDates(aID, dateFrom, dateTo).ToList();
        }

        /// <summary>
        /// Gets order by date and account ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="date">The date</param>
        /// <returns>The order</returns>
        public Common.Order getOrderByDateAndAccount(int aID, DateTime date)
        {
            return new DAOrder().getOrderByDateAndAccount(aID, date);
        }
    }
}
