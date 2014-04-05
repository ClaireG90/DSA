using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductComment" in both code and config file together.
    [ServiceContract]
    public interface IProductComment
    {
        [OperationContract]
        List<Common.Comment> GetCommentsByProductID(int id);
    }
}
