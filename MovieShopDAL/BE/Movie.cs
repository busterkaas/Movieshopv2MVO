using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShopDAL.BE
{
    public class Movie
    {
     
        public int MovieId { get; set; }
        [Required(ErrorMessage = "A Title is required!")]
        public int GenreId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Year { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1, 1000,
            ErrorMessage = "Price must be between 1 and 100")]
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public virtual Genre Genre { get; set; }

        //public List<Orderline> Orders { get; set; }
        
    }
}