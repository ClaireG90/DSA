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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductComment" in code, svc and config file together.
    public class ProductComment : IProductComment
    {
        /// <summary>
        /// Gets comment by product
        /// </summary>
        /// <param name="id">The product ID</param>
        /// <returns>A list of comments</returns>
        public List<Common.Comment> GetCommentsByProductID(int id)
        {
            return new DAProductComment().GetCommentsByProductID(id).ToList();
        }

        /// <summary>
        /// Adds a comment
        /// </summary>
        /// <param name="comment">The comment</param>
        public void AddComment(Comment comment)
        {
            new DAProductComment().AddComment(comment);
        }
    }
}
