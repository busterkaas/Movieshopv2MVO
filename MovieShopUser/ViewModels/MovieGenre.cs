using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUser.ViewModels
{
    public class MovieGenre
    {
        public List<Movie> Movies { get; set; }

        public void setMovieList(List<Movie> movies)
        {
            Movies = movies;
        }

        public List<Genre> Genres { get; set; }

        public void setGenreList(List<Genre> genres)
        {
            Genres = genres;
        }



        public MovieGenre()
        {

        }
    }
}