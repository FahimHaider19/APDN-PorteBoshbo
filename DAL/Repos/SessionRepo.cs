using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SessionRepo : IRepo<Session>
    {
        private PorteBoshboEntities db = new PorteBoshboEntities();
        public bool Add(Session obj)
        {
            db.Sessions.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Session Get(int id)
        {
            return db.Sessions.Find(id);
        }

        public List<Session> GetAll()
        {
            return db.Sessions.ToList();
        }

        public bool Remove(int id)
        {
            db.Sessions.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(Session obj)
        {
            db.Entry(Get(obj.SessionId)).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
