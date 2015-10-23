using System.Data;
using System.Linq;
using System.Web.Mvc;
using MovieShopDAL;
using MovieShopDAL.Repositories;
using MovieShopDAL.BE;

namespace MovieShopAdminv2.Controllers
{
    public class MoviesController : Controller
    {
        private IRepository<Movie> movieRepo = new DALFacade().MovieRepository;
        private IRepository<Genre> genreRepo = new DALFacade().GenreRepository;

        // GET: Movies
        public ActionResult Index(string GenreList, string PriceList)
        {
            var movies = movieRepo.GetAll();
            ViewBag.GenreList = new SelectList(genreRepo.GetAll().OrderBy(g => g.Name).Select(g => g.Name));
            ViewBag.PriceList = new SelectList(movieRepo.GetAll().OrderBy(g => g.Price).Select(g => g.Price));

            if (string.IsNullOrEmpty(GenreList))
                return View(movies);
            else
            {
                return View(movies.Where(a => a.Genre.Name == GenreList));
            }

        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = movieRepo.Get(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(genreRepo.GetAll(), "GenreId", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,GenreId,Title,Year,Price,ImageUrl,TrailerUrl")] Movie movie, string Command)
        {
                if (ModelState.IsValid)
                {
                    movieRepo.Add(movie);
                    return RedirectToAction("Index");
                }

            ViewBag.GenreId = new SelectList(genreRepo.GetAll(), "GenreId", "Name", movie.Genre.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {

            Movie movie = movieRepo.Get(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(genreRepo.GetAll(), "GenreId", "Name", movie.Genre.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,GenreId,Title,Year,Price,ImageUrl,TrailerUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepo.Edit(movie);
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(genreRepo.GetAll(), "GenreId", "Name", movie.Genre.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = movieRepo.Get(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            movieRepo.Remove(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}
