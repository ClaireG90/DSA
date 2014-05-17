using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProduct" in both code and config file together.
    [ServiceContract]
    public interface IProduct
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>A list of products</returns>
        [OperationContract]
        IEnumerable<Common.Product> GetAllProducts();

        /// <summary>
        /// Gets a product by ID
        /// </summary>
        /// <param name="id">The product ID</param>
        /// <returns>The product</returns>
        [OperationContract]
        Common.Product GetProductByID(int id);

        /// <summary>
        /// Gets the product category by name
        /// </summary>
        /// <param name="name">The category name</param>
        /// <returns>The category</returns>
        [OperationContract]
        Common.Category getCategoryByName(string name);

        /// <summary>
        /// Gets prroducts by category ID
        /// </summary>
        /// <param name="cID">The category ID</param>
        /// <returns>A list of products</returns>
        [OperationContract]
        List<Common.Product> GetProductsByCategory(int cID);

        /// <summary>
        /// Gets products by their name
        /// </summary>
        /// <param name="name">A phrase to match with the product name</param>
        /// <returns>A list of products</returns>
        [OperationContract]
        List<Common.Product> GetProductsByName(string name);

        /// <summary>
        /// Gets products within a price range
        /// </summary>
        /// <param name="priceFrom">The price from</param>
        /// <param name="priceTo">The price to</param>
        /// <returns>A list of products</returns>
        [OperationContract]
        List<Common.Product> GetProductsByPriceRange(decimal priceFrom, decimal priceTo);

        /// <summary>
        /// Gets products sorted by price ascending
        /// </summary>
        /// <returns>A list of products</returns>
        [OperationContract]
        List<Common.Product> sortByPriceAsc();

        /// <summary>
        /// Gets products sorted by price descending
        /// </summary>
        /// <returns>A list of products</returns>
        [OperationContract]
        List<Common.Product> sortByPriceDesc();

        /// <summary>
        /// Gets products sorted by date listed
        /// </summary>
        /// <returns>A list of products</returns>
        [OperationContract]
        List<Common.Product> sortByDateListed();

        /// <summary>
        /// Adds a product rating
        /// </summary>
        /// <param name="rating">The rating</param>
        [OperationContract]
        void AddRating(Common.Rating rating);

        /// <summary>
        /// Gets average rating product ID
        /// </summary>
        /// <param name="pID">The product ID</param>
        /// <returns>The average rating</returns>
        [OperationContract]
        double GetRatingsByProduct(int pID);

        /// <summary>
        /// Gets rating by account ID and product ID
        /// </summary>
        /// <param name="aID">The account ID</param>
        /// <param name="pID">The product ID</param>
        /// <returns>The rating</returns>
        [OperationContract]
        Common.Rating GetRatingByAccountAndProduct(int aID, int pID);

        /// <summary>
        /// Gets a highest rating
        /// </summary>
        /// <returns>The rating</returns>
        [OperationContract]
        List<Common.Rating> GetHighlyRatedItem();

        /// <summary>
        /// Gets the most purchased product in a product order
        /// </summary>
        /// <returns>The product order</returns>
        [OperationContract]
        List<Common.ProductOrder> GetMostPurchasedItem();

        /// <summary>
        /// Gets the product with most faults in a fault
        /// </summary>
        /// <returns>The fault</returns>
        [OperationContract]
        List<Common.Fault> GetProductWithMostFaults();

        /// <summary>
        /// Gets the product with the least faults in a fault
        /// </summary>
        /// <returns>The fault</returns>
        [OperationContract]
        List<Common.Fault> GetProductWithLeastFaults();
    }
}
