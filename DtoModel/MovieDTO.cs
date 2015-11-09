using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public GenreDTO Genre { get; set; }
    }
}
