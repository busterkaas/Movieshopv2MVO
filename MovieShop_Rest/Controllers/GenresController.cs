using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DtoModel.Converter;
using MovieShopDAL;
using MovieShopDAL.BE;
using MovieShopDTO.ModelDTO;

namespace MovieShop_Rest.Controllers
{
    public class GenresController : ApiController
    {
        DALFacade df = new DALFacade();

        // GET: api/Genres
        public IEnumerable<GenreDTO> GetGenres()
        {
            var genres = df.GenreRepository.GetAll();
            return new GenreConverter().Convert(genres);
        }

        //GET: api/Genres/5
        [ResponseType(typeof(GenreDTO))]
        public IHttpActionResult GetGenre(int id)
        {
            var genre = df.GenreRepository.Get(id);
            GenreDTO genreDTO = new GenreConverter().Convert(genre);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genreDTO);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, GenreDTO genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.GenreId)
            {
                return BadRequest();
            }
            try
            {
                df.GenreRepository.Edit(new GenreConverter().Reverse(genre));
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Genres
        [ResponseType(typeof(GenreDTO))]
        public IHttpActionResult PostGenre(GenreDTO genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            df.GenreRepository.Add(new GenreConverter().Reverse(genre));
          
            return CreatedAtRoute("DefaultApi", new { id = genre.GenreId }, genre);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(GenreDTO))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = df.GenreRepository.Get(id);
            if (genre == null)
            {
                return NotFound();
            }

           df.GenreRepository.Remove(genre.GenreId);

            return Ok(genre);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool GenreExists(int id)
        //{
        //    return db.Genres.Count(e => e.GenreId == id) > 0;
        //}
    }
}