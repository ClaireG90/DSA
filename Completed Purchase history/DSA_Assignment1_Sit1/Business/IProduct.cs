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
        [OperationContract]
        IEnumerable<Common.Product> GetAllProducts();

        [OperationContract]
        Common.Product GetProductByID(int id);

        [OperationContract]
        Common.Category getCategoryByName(string name);

        [OperationContract]
        List<Common.Product> GetProductsByCategory(int cID);

        [OperationContract]
        List<Common.Product> GetProductsByName(string name);

        [OperationContract]
        List<Common.Product> GetProductsByPriceRange(decimal priceFrom, decimal priceTo);

        [OperationContract]
        List<Common.Product> sortByPriceAsc();

        [OperationContract]
        List<Common.Product> sortByPriceDesc();

        [OperationContract]
        List<Common.Product> sortByDateListed();
    }
}
