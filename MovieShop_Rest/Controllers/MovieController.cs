using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        // The method name starts with "Get", so by convention it maps to GET requests.
        // Also, because the method has no parameters, it maps to a URI that does not 
        // contain an "id" segment in the path. Instead of using "convention-based" 
        // routing, you could define the route yourself with an attribute. This is
        // called attribute routing.

        /// <summary>
        /// Returns all movies
        /// </summary>
        /// <returns>Array of Movies</returns>
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = df.MovieRepository.GetAll();
            return new MovieDtoConverter().Convert(movies);
        }

        /// <summery>
        /// Finds a Movie by Id
        /// </summery>
        /// <param name="id">Movie Id</param>
        /// <returns>Movie</returns>
        //public Movie GetMovie(int id)
        //{
        //   Movie movie = df.MovieRepository.Get(id);
        //   MovieDto movieDto = new MovieDtoConverter().Convert(movie);
        //    if (movie == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return movieDto;
        //}

        public MovieDto PostMovie(MovieDto dto)
        {
            return dto;
        }
    }
}
