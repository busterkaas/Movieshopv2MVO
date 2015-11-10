using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieShopDAL;
using MovieShopDTO.Converter;
using MovieShopDTO.ModelDTO;

namespace MovieShop_Rest.Controllers
{
    public class MovieController : ApiController
    {
        DALFacade df = new DALFacade();
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = df.MovieRepository.GetAll();
            return new MovieDtoConverter().Convert(movies);
        }

        public MovieDto PostMovie(MovieDto dto)
        {
            return dto;
        }
    }
}
