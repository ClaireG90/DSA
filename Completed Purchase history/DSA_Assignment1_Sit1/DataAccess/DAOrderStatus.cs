using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAOrderStatus : Connection
    {
        public DAOrderStatus()
            : base()
        { }

        public DAOrderStatus(Entities entities)
            : base(entities)
        { }

        public OrderStatus GetOrderStatusByID(int id)
        {
            return entities.OrderStatus.SingleOrDefault(os => os.ID == id);
        }

        public OrderStatus GetOrderStatusByName(string name)
        {
            return entities.OrderStatus.SingleOrDefault(os => os.Name == name);
        }
    }
}
