using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAOrder : Connection
    {
        public DAOrder()
            : base()
        { }

        public DAOrder(Entities entities)
            : base(entities)
        { }

        public void AddOrder(Order order)
        {
            entities.Order.AddObject(order);
            entities.SaveChanges();
        }

        public Order GetOrderByID(int id)
        {
            return entities.Order.SingleOrDefault(o => o.ID == id);
        }

        public IEnumerable<Order> GetOrdersByAccountID(int aid)
        {
            return entities.Order.Where(o => o.AccountID == aid);
        }

        public Order GetOrderByAccountAndStatus(int aid, int sid)
        {
            return entities.Order.SingleOrDefault(o => o.AccountID == aid && o.StatusID == sid);
        }
    }
}
