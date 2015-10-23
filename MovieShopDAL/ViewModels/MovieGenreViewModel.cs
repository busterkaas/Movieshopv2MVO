using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.ViewModels
{
    class MovieGenreViewModel
    {
        public MovieGenreViewModel()
        {
            Movies = new List<Movie>();
            Genres = new List<Genre>();
        }
        public Movie Movie { get; set; }

        public Genre Genre { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
