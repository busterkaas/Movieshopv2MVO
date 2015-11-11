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
    public class GenreConverter : AbstractDtoConverter<Genre, GenreDTO>
    {
        public override GenreDTO Convert(Genre item)
        {
            var genreDto = new GenreDTO()
            {
                GenreId = item.GenreId,
                Name = item.Name
            };
            return genreDto;
        }

        public override Genre Reverse(GenreDTO item)
        {
            var genre = new Genre()
            {
                GenreId = item.GenreId,
                Name = item.Name
            };
            return genre;
        }
    }
}
