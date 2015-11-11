using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDAL;
using MovieShopDAL.BE;
using MovieShopDTO.Converter;
using MovieShopDTO.ModelDTO;

namespace MovieShop_Rest.Controllers
{
    public class MovieController : ApiController
    {
        DALFacade df = new DALFacade();

        // GET /api/movie
        /// <summary>
        /// Returns all movies
        /// </summary>
        /// <returns>Array of Movies</returns>
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = df.MovieRepository.GetAll();
            return new MovieDtoConverter().Convert(movies);
        }

        // GET /api/movie/id
        /// <summary>
        /// Finds a Movie by Id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>Movie</returns>
        [ResponseType(typeof(MovieDto))]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = df.MovieRepository.Get(id);
            MovieDto movieDto = new MovieDtoConverter().Convert(movie);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(movieDto);
        }

        //---------------------Mangler------------------------------------------------------------
        //// POST/ api/movies
        ///// <summary>
        ///// Creates a new movie and adds it to the list of products
        ///// </summary>
        ///// <param name="movie">Product</param>
        ///// <returns>Http response message containing the Movie, its URI, and a HTTP status code</returns>
        //[ResponseType(typeof(Movie))]
        //public IHttpActionResult PostMovie(Movie movie)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    df.MovieRepository.Add(movie);

        //    return Ok(movie);
        //}
        //---------------------Mangler------------------------------------------------------------------

        // PUT /api/Movies/id
        /// <summary>
        /// Replaces a movie with a new product
        /// </summary>
        /// <param name="id">Movie Id of the movie to replace</param>
        /// <param name="movie">The new movie</param>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.GenreId)
            {
                return BadRequest();
            }
            try
            {
                df.MovieRepository.Edit(new MovieDtoConverter().Reverse(movie));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE /api/Genres/5
        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id">Movie Id of the movie that should be deleted</param>
        [ResponseType(typeof(MovieDto))]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = df.MovieRepository.Get(id);
            MovieDto movieDto = new MovieDtoConverter().Convert(movie);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            df.MovieRepository.Remove(id);

            return Ok(movieDto);
        }

    }
}
