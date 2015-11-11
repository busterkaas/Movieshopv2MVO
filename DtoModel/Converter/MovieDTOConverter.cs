using MovieShopDAL.BE;
using MovieShopDTO.ModelDTO;

namespace MovieShopDTO.Converter
{
    public class MovieDtoConverter : AbstractDtoConverter<Movie, MovieDto>
    {
        public override MovieDto Convert(Movie movie)
        {
            var dto = new MovieDto()
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

        public override Movie Reverse(MovieDto movieDto)
        {
            var movie = new Movie()
            {
                MovieId = movieDto.MovieId,
                GenreId = movieDto.GenreId,
                Title = movieDto.Title,
                Year = movieDto.Year,
                Price = movieDto.Price,
                ImageUrl = movieDto.ImageUrl,
                TrailerUrl = movieDto.TrailerUrl
            };

            if (movieDto.Genre != null)
            {
                movie.Genre = new Genre()
                {
                    GenreId = movieDto.Genre.GenreId,
                    Name = movieDto.Genre.Name
                };
            }

            return movie;
        }
    }
}
