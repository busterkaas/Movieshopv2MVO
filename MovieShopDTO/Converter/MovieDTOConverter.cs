using MovieShopDAL.BE;
using MovieShopDTO.ModelDTO;

namespace MovieShopDTO.Converter
{
    public class MovieDTOConverter : AbstractDtoConverter<Movie, MovieDTO>
    {
        public override MovieDTO Convert(Movie movie)
        {
            var dto = new MovieDTO()
            {
                MovieId = movie.MovieId,
                GenreId = movie.GenreId,
                Title = movie.Title,
                Year = movie.Year,
                Price = movie.Price,
                ImageUrl = movie.ImageUrl,
                TrailerUrl = movie.TrailerUrl
            };

            if (movie.Genre != null)
            {
                dto.Genre = new GenreDTO()
                {
                    GenreId = movie.Genre.GenreId,
                    Name = movie.Genre.Name
                };
            }

            return dto;
        }
    }
}
