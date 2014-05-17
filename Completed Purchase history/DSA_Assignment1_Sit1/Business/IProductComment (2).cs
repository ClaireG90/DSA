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
        /// <summary>
        /// Gets comment by product
        /// </summary>
        /// <param name="id">The product ID</param>
        /// <returns>A list of comments</returns>
        [OperationContract]
        List<Common.Comment> GetCommentsByProductID(int id);

        /// <summary>
        /// Adds a comment
        /// </summary>
        /// <param name="comment">The comment</param>
        [OperationContract]
        void AddComment(Comment comment);
    }
}
