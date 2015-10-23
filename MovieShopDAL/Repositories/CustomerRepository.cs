using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace MovieShopDAL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private MovieShopDBContext db = new MovieShopDBContext();

        SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;
    
        public void Add(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
        }

        public void Edit(Customer entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(g => g.CustomerId == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public void Remove(int id)
        {
            db.Customers.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
