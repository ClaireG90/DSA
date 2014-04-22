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

        public DAProduct(Entities entities)
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

        public IEnumerable<Product> GetProductsByCategory(int cID)
        {
            return entities.Product.Where(p => p.CategoryID == cID);
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return entities.Product.Where(p => p.Name.Contains(name));
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal priceFrom, decimal priceTo)
        {
            return entities.Product.Where(p => p.Price >= priceFrom && p.Price <= priceTo);
        }

        public IEnumerable<Product> sortByPriceAsc()
        {
            return entities.Product.OrderBy(p => p.Price);
        }

        public IEnumerable<Product> sortByPriceDesc()
        {
            return entities.Product.OrderByDescending(p => p.Price);
        }

        public IEnumerable<Product> sortByDateListed()
        {
            return entities.Product.OrderBy(p => p.DateListed);
        }
    }
}
