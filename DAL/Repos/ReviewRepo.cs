using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewRepo : IRepo<Review>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(Review obj)
        {
            db.Reviews.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }

        public List<Review> GetAll()
        {
            return db.Reviews.ToList();
        }

        public bool Remove(int id)
        {
            db.Reviews.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(Review obj)
        {
            db.Entry(Get(obj.ReviewId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
