using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDAL.BE;
using MovieShopDTO.Converter;
using MovieShopDTO.ModelDTO;

namespace DtoModel.Converter
{
    class GenreConverter : AbstractDtoConverter<Genre, GenreDTO>
    {
        public override GenreDTO Convert(Genre item)
        {
            var genreDto = new GenreDTO()
            {
                GenreId = item.GenreId,
                Name = item.Name
            };
            //if (item.Movies != null)
            //{
            //    GenreDto.Movies = new List<MovieDTO>();
            //    foreach (var movie in item.Movies)
            //    {
            //        GenreDto.Movies.Add(new MovieDTO()
            //        {
            //            MovieId = movie.MovieId,
            //            GenreId = movie.GenreId,
            //            Title = movie.Title,
            //            Year = movie.Year,
            //            Price = movie.Price,
            //            ImageUrl = movie.ImageUrl,
            //            TrailerUrl = movie.TrailerUrl,
            //            Genre = GenreDto                       
            //        });
            //    }
            //}
            return genreDto; ;
        }
    }
}
