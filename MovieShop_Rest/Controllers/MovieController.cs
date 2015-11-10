using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DtoModel;
using DtoModel.Converter;
using MovieShopDAL;

namespace MovieShop_Rest.Controllers
{
    public class MovieController : ApiController
    {
        DALFacade df = new DALFacade();
        public IEnumerable<MovieDTO> getMovies()
        {
            var movies = df.MovieRepository.GetAll();
            return new MovieDTOConverter().Convert(movies);
        }

        public MovieDTO PostMovie(MovieDTO dto)
        {

            return dto;
        }
    }
}
