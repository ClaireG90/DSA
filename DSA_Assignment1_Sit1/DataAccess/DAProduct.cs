using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAProduct : Connection
    {
        public DAProduct()
            : base()
        { }

        public DAProduct(Entitie entities)
            : base(entities)
        { }

        public IEnumerable<Product> GetAllProducts()
        {
            return entities.Product.AsEnumerable();   
        }

        public Product GetProductByID(int id)
        {
            return entities.Product.SingleOrDefault(p => p.ID == id);
        }
    }
}
