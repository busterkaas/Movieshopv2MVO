using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MovieShopDAL
{
    public class MovieShopDBInitializer : DropCreateDatabaseIfModelChanges<MovieShopDBContext>
    {
        //Opret genre 

        protected override void Seed(MovieShopDBContext context)
        {

            Customer cus = new Customer { City = "Esbjerg", Email = "bulle@gmail.com", FirstName = "Buster", LastName = "Jensen", HouseNr = "175 C, 2th", StreetName = "Ingemanns Allé", ZipCode = 6700 };

            context.Customers.Add(cus);


            Genre myGenre1 = new Genre { Name = "XXX" };
            Genre myGenre2 = new Genre { Name = "Action" };
            Genre myGenre3 = new Genre { Name = "Comedy" };
            Genre myGenre4 = new Genre { Name = "Horror" };
            Genre myGenre5 = new Genre { Name = "Adventure" };
            Genre myGenre6 = new Genre { Name = "Documentary" };
            Genre myGenre7 = new Genre { Name = "Thriller" };
            Genre myGenre8 = new Genre { Name = "Musical" };
            Genre myGenre9 = new Genre { Name = "Sport" };
            Genre myGenre10 = new Genre { Name = "History" };

            //Opret Movie

            List<Movie> movies = new List<Movie> {
                new Movie { Title = "Mission Impossible", Genre = myGenre2, Year = DateTime.Now, Price = 60, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTc3NjI2MjU0Nl5BMl5BanBnXkFtZTgwNDk3ODYxMTE@._V1_SX214_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/QBavzf2_ook" },
                new Movie { Title = "Avatar", Genre = myGenre2, Year = DateTime.Now, Price = 100, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SY317_CR0,0,214,317_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/5PSNL1qE6VY" },
                new Movie { Title = "Interstellar", Genre = myGenre2, Year = DateTime.Now, Price = 125, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMjIxNTU4MzY4MF5BMl5BanBnXkFtZTgwMzM4ODI3MjE@._V1_SX214_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/zSWdZVtXT7E" },
                 new Movie { Title = "Lego the movie", Genre = myGenre3, Year = DateTime.Now, Price = 60, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTg4MDk1ODExN15BMl5BanBnXkFtZTgwNzIyNjg3MDE@._V1_SX214_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/fZ_JOBCLF-I" },
                new Movie { Title = "The Grudge", Genre = myGenre4, Year = DateTime.Now, Price = 70, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMjIxODg1Nzc3NF5BMl5BanBnXkFtZTcwMjM0MjEzMw@@._V1_SX214_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/bj88_yqlFMA" },
                new Movie { Title = "Toy Story", Genre = myGenre2, Year = DateTime.Now, Price = 75, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTgwMjI4MzU5N15BMl5BanBnXkFtZTcwMTMyNTk3OA@@._V1_SY317_CR12,0,214,317_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/KYz2wyBy3kc" },
                 new Movie { Title = "Kung Pow: Enter the fist", Genre = myGenre1, Year = DateTime.Now, Price = 60, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTYyODQwODY1N15BMl5BanBnXkFtZTcwNzE3ODI1MQ@@._V1_SY317_CR9,0,214,317_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/GXrAYdSeWY8" },
                new Movie { Title = "Die Hard", Genre = myGenre2, Year = DateTime.Now, Price = 70, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTY4ODM0OTc2M15BMl5BanBnXkFtZTcwNzE0MTk3OA@@._V1_SX214_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/2TQ-pOvI6Xo" },
                new Movie { Title = "Die Hard 2", Genre = myGenre2, Year = DateTime.Now, Price = 75, ImageUrl = "http://ia.media-imdb.com/images/M/MV5BNzM1MzMwNzY2OF5BMl5BanBnXkFtZTgwNzE1MzkyMTE@._V1_SX214_AL_.jpg", TrailerUrl = "https://www.youtube.com/embed/JZPuK8QEU2k" }
        };
            context.Genres.Add(myGenre3);
            context.Genres.Add(myGenre5);
            context.Genres.Add(myGenre6);
            context.Genres.Add(myGenre7);
            context.Genres.Add(myGenre8);
            context.Genres.Add(myGenre9);
            context.Genres.Add(myGenre10);

            context.Movies.AddRange(movies);
            

            base.Seed(context);
        }


    }
}
