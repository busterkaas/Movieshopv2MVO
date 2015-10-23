using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repositories
{
    class OrderRepository : IRepository<Order>
    {
        private MovieShopDBContext db = new MovieShopDBContext();

        SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;

        public void Add(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
        }

        public void Edit(Order entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(m => m.OrderId == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public void Remove(int id)
        {
            db.Orders.Remove(Get(id));
            db.SaveChanges();
        }
    }
}