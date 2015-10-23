using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repositories
{
    class OrderlineRepository : IRepository<Orderline>
    {
        private MovieShopDBContext db = new MovieShopDBContext();

        SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;

        public void Add(Orderline entity)
        {
            db.Orderlines.Add(entity);
            db.SaveChanges();
        }

        public void Edit(Orderline entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Orderline Get(int id)
        {
            return db.Orderlines.FirstOrDefault(m => m.OrderId == id);
        }

        public IEnumerable<Orderline> GetAll()
        {
            return db.Orderlines.ToList();
        }

        public void Remove(int id)
        {
            db.Orderlines.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
