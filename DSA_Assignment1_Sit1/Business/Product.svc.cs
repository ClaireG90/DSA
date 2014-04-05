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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Product" in code, svc and config file together.
    public class Product : IProduct
    {

        public IEnumerable<Common.Product> GetAllProducts()
        {
            return new DAProduct().GetAllProducts();
        }

        public Common.Product GetProductByID(int id)
        {
            return new DAProduct().GetProductByID(id);
        }
    }
}
