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
        public Common.OrderStatus GetOrderStatusByID(int id)
        {
            return new DAOrderStatus().GetOrderStatusByID(id);
        }

        public Common.OrderStatus GetOrderStatusByName(string name)
        {
            return new DAOrderStatus().GetOrderStatusByName(name);
        }

        public Common.Order GetOrderByAccountAndStatus(int aid, int sid)
        {
            return new DAOrder().GetOrderByAccountAndStatus(aid, sid);
        }

        public void AddProductOrder(Common.ProductOrder po)
        {
            new DAProductOrder().AddProductOrder(po);
        }

        public void AddOrder(Common.Order order)
        {
            new DAOrder().AddOrder(order);
        }

        public Common.Order GetOrderByID(int id)
        {
            return new DAOrder().GetOrderByID(id);
        }

        public IEnumerable<Common.Order> GetOrdersByAccountID(int aid)
        {
            return new DAOrder().GetOrdersByAccountID(aid);
        }

        public Common.ProductOrder GetProductOrderByOrderIDAndProductID(int oID, int pID)
        {
            return new DAProductOrder().GetProductOrderByOrderIDAndProductID(oID, pID);
        }

        public List<Common.ProductOrder> GetProductOrderByOrderID(int oID)
        {
            return new DAProductOrder().GetProductOrderByOrderID(oID).ToList();
        }

        public void UpdateProductOrder(Common.ProductOrder po)
        {
            new DAProductOrder().UpdateProductOrder(po);
        }

        public List<Common.Order> GetBoughtOrdersByAccountID(int aid)
        {
            return new DAOrder().GetBoughtOrdersByAccountID(aid).ToList();
        }

        public void UpdateOrder(Common.Order order)
        {
            new DAOrder().UpdateOrder(order);
        }

        public void DeleteProductOrder(int oID, int pID)
        {
            new DAProductOrder().DeleteProductOrder(oID, pID);
        }

        public List<Common.ProductOrder> GetWarrantyUnexpiredOrdersByOrderID(int oID)
        {
            return new DAProductOrder().GetWarrantyUnexpiredOrdersByOrderID(oID).ToList();
        }
    }
}
