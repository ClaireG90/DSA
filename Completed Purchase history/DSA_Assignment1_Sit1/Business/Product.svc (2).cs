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
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>A list of products</returns>
        public IEnumerable<Common.Product> GetAllProducts()
        {
            return new DAProduct().GetAllProducts();
        }

        /// <summary>
        /// Gets a product by ID
        /// </summary>
        /// <param name="id">The product ID</param>
        /// <returns>The product</returns>
        public Common.Product GetProductByID(int id)
        {
            return new DAProduct().GetProductByID(id);
        }

        /// <summary>
        /// Gets the product category by name
        /// </summary>
        /// <param name="name">The category name</param>
        /// <returns>The category</returns>
        public Common.Category getCategoryByName(string name)
        {
            return new DACategory().getCategoryByName(name);
        }

        /// <summary>
        /// Gets the product category by name
        /// </summary>
        /// <param name="name">The category name</param>
        /// <returns>The category</returns>
        public List<Common.Product> GetProductsByCategory(int cID)
        {
            return new DAProduct().GetProductsByCategory(cID).ToList();
        }

        /// <summary>
        /// Gets products by their name
        /// </summary>
        /// <param name="name">A phrase to match with the product name</param>
        /// <returns>A list of products</returns>
        public List<Common.Product> GetProductsByName(string name)
        {
            return new DAProduct().GetProductsByName(name).ToList();
        }

        /// <summary>
        /// Gets products within a price range
        /// </summary>
        /// <param name="priceFrom">The price from</param>
        /// <param name="priceTo">The price to</param>
        /// <returns>A list of products</returns>
        public List<Common.Product> GetProductsByPriceRange(decimal priceFrom, decimal priceTo)
        {
            return new DAProduct().GetProductsByPriceRange(priceFrom, priceTo).ToList();
        }

        /// <summary>
        /// Gets products sorted by price ascending
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Common.Product> sortByPriceAsc()
        {
            return new DAProduct().sortByPriceAsc().ToList();
        }

        /// <summary>
        /// Gets products sorted by price descending
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Common.Product> sortByPriceDesc()
        {
            return new DAProduct().sortByPriceDesc().ToList();
        }

        /// <summary>
        /// Gets products sorted by date listed
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Common.Product> sortByDateListed()
        {
            return new DAProduct().sortByDateListed().ToList();
        }

        /// <summary>
        /// Adds a product rating
        /// </summary>
        /// <param name="rating">The rating</param>
        public void AddRating(Common.Rating rating)
        {
            new DARating().AddRating(rating);
        }

        /// <summary>
        /// Gets average rating product ID
        /// </summary>
        /// <param name="pID">The product ID</param>
        /// <returns>The average rating</returns>
        public double GetRatingsByProduct(int pID)
        {
            return new DARating().GetRatingsByProduct(pID);
        }

        /// <summary>
        /// Gets rating by account ID and product ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="pID">The product ID</param>
        /// <returns>The rating</returns>
        public Common.Rating GetRatingByAccountAndProduct(int aID, int pID)
        {
            return new DARating().GetRatingByAccountAndProduct(aID, pID);
        }

        /// <summary>
        /// Gets a highest rating
        /// </summary>
        /// <returns>The rating</returns>
        public List<Common.Rating> GetHighlyRatedItem()
        {
            return new DAProduct().GetHighlyRatedItem().ToList();
        }

        /// <summary>
        /// Gets the most purchased product in a product order
        /// </summary>
        /// <returns>The product order</returns>
        public List<Common.ProductOrder> GetMostPurchasedItem()
        {
            return new DAProduct().GetMostPurchasedItem().ToList();
        }

        /// <summary>
        /// Gets the product with most faults in a fault
        /// </summary>
        /// <returns>The fault</returns>
        public List<Common.Fault> GetProductWithMostFaults()
        {
            return new DAProduct().GetProductWithMostFaults().ToList();
        }

        /// <summary>
        /// Gets the product with the least faults in a fault
        /// </summary>
        /// <returns>The fault</returns>
        public List<Common.Fault> GetProductWithLeastFaults()
        {
            return new DAProduct().GetProductWithLeastFaults().ToList();
        }
    }
}
