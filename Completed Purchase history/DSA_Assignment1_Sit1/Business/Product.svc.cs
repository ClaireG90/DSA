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

        public Common.Category getCategoryByName(string name)
        {
            return new DACategory().getCategoryByName(name);
        }

        public List<Common.Product> GetProductsByCategory(int cID)
        {
            return new DAProduct().GetProductsByCategory(cID).ToList();
        }

        public List<Common.Product> GetProductsByName(string name)
        {
            return new DAProduct().GetProductsByName(name).ToList();
        }

        public List<Common.Product> GetProductsByPriceRange(decimal priceFrom, decimal priceTo)
        {
            return new DAProduct().GetProductsByPriceRange(priceFrom, priceTo).ToList();
        }

        public List<Common.Product> sortByPriceAsc()
        {
            return new DAProduct().sortByPriceAsc().ToList();
        }

        public List<Common.Product> sortByPriceDesc()
        {
            return new DAProduct().sortByPriceDesc().ToList();
        }

        public List<Common.Product> sortByDateListed()
        {
            return new DAProduct().sortByDateListed().ToList();
        }
    }
}
