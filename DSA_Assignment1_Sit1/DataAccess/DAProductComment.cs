using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DAProductComment : Connection
    {

        public DAProductComment()
            : base()
        { }

        public DAProductComment(Entities entities)
            : base(entities)
        { }

        public IEnumerable<Comment> GetCommentsByProductID(int id)
        {
            return entities.Comment.Where(c => c.ProductID == id);
        }

        public void AddComment(Comment comment)
        {
            entities.Comment.AddObject(comment);
            entities.SaveChanges();
        }
    }
}
