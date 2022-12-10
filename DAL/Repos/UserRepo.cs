using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : IRepo<User>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public bool Remove(int id)
        {
            db.Users.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(User obj)
        {
            db.Entry(Get(obj.UserId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
