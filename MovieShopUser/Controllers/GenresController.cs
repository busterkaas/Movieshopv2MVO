using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopDAL;
using MovieShopDAL.BE;

namespace MovieShopUser.Controllers
{
    public class GenresController : Controller
    {
        DALFacade DF = new DALFacade();

        // GET: Genres
        public ActionResult Index()
        {
            return View(DF.GenreRepository.GetAll().ToList());
        }

    }

}
