using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class DARating : Connection
    {
        public DARating()
            : base()
        { }

        public DARating(Entities entities)
            : base()
        { }

        public void AddRating(Rating rating)
        {
            entities.Rating.AddObject(rating);
            entities.SaveChanges();
        }

        public double GetRatingsByProduct(int pID)
        {
            return Convert.ToDouble(entities.Rating.Where(r => r.ProductID == pID).Average(r => r.Rating1));
        }

        public Rating GetRatingByAccountAndProduct(int aID, int pID)
        {
            return entities.Rating.SingleOrDefault(r => r.AccountID == aID && r.ProductID == pID);
        }
    }
}
