using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieShopDBContext db = new MovieShopDBContext();

       SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;

        public void Add(Movie entity)
        {
            using (var db = new MovieShopDBContext())
            {
                db.Movies.Add(entity);
                db.SaveChanges();
            }
        }

        //public void Dispose()
        //{
        //    db.Dispose();
        //}

        public void Edit(Movie entity)
        {
            using (var db = new MovieShopDBContext()) { 
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        }

        public Movie Get(int id)
        {
            //var movie = (from m in db.Movies
            //            where m.MovieId == id
            //            select m).FirstOrDefault();
            //return db.Movies.Include(g => g.Genre).FirstOrDefault(m => m.MovieId == id);
            return db.Movies.FirstOrDefault(m => m.MovieId == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            //return db.Movies.Include(a => a.Genre).Include(g => g.Order).Tolist();
            //return db.Movies.Include(a => a.Genre);

            return db.Movies.ToList();
        }

        public void Remove(int id)
        {
            //Ingen fejlhåndtering
            //var movie = this.Get(id);
            db.Movies.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
