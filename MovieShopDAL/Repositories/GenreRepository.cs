using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private MovieShopDBContext db = new MovieShopDBContext();

        SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;

        public void Add(Genre entity)
        {
                db.Genres.Add(entity);
                db.SaveChanges();
        }

        //public void Dispose()
        //{
        //    db.Dispose();
        //}

        public void Edit(Genre entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Genre Get(int id)
        {
            //var movie = (from m in db.Movies
            //            where m.MovieId == id
            //            select m).FirstOrDefault();
            //return db.Movies.Include(g => g.Genre).FirstOrDefault(m => m.MovieId == id);
            return db.Genres.FirstOrDefault(g => g.GenreId == id);
        }

        public IEnumerable<Genre> GetAll()
        {
            //return db.Movies.Include(a => a.Genre).Include(g => g.Order).Tolist();
            //return db.Movies.Include(a => a.Genre);

            return db.Genres.ToList();
        }

        public void Remove(int id)
        {
            //Ingen fejlhåndtering
            //var movie = this.Get(id);
            db.Genres.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
