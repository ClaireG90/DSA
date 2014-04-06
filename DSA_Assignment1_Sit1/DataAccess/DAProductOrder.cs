﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAProductOrder : Connection
    {
        public DAProductOrder()
            : base()
        { }

        public DAProductOrder(Entities entities)
            : base(entities)
        { }

        public void AddProductOrder(ProductOrder po)
        {
            entities.ProductOrder.AddObject(po);
            entities.SaveChanges();
        }

        public void UpdateProductOrder(ProductOrder po)
        {
            entities.ProductOrder.Attach(GetProductOrderByOrderIDAndProductID(po.OrderID, po.ProductID));
            entities.ProductOrder.ApplyCurrentValues(po);
            entities.SaveChanges();
        }

        public void DeleteProductOrder(ProductOrder po)
        {
            entities.ProductOrder.DeleteObject(po);
            entities.SaveChanges();
        }

        public ProductOrder GetProductOrderByOrderIDAndProductID(int oID, int pID)
        {
            return entities.ProductOrder.SingleOrDefault(po => po.OrderID == oID && po.ProductID == pID);
        }
    }
}
