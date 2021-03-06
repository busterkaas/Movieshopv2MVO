﻿using MovieShopDAL;
using MovieShopDAL.BE;
using MovieShopDAL.Repositories;
using System.Web.Mvc;
using MovieShopAdminv2.Infrastructure;

namespace MovieShopAdminv2.Controllers
{
    public class GenresController : Controller
    {
        //private IRepository<Genre> genreRepo = new DALFacade().GenreRepository;
        GenreServiceGateway gsg = new GenreServiceGateway();

        // GET: Genres
        public ActionResult Index()
        {
            var genres = gsg.GetAll();
            return View(genres);
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            var genres = gsg.Get(id);
            if (genres == null)
            {
                return HttpNotFound();
            }
            return View(genres);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                gsg.Create(genre);
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            var genres = gsg.Get(id);
            if (genres == null)
            {
                return HttpNotFound();
            }
            return View(genres);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                gsg.Update(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            Genre genres = gsg.Get(id);
            if (genres == null)
            {
                return HttpNotFound();
            }
            return View(genres);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gsg.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
