using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MovieShopDAL.BE;

namespace MovieShopAdminv2.Infrastructure
{
    public class MovieServiceGateway : IServiceGateway<Movie>
    {
        ServiceGateway sg = new ServiceGateway();

        public HttpResponseMessage Create(Movie t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/movie", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/movie/"+ id).Result;
            return response;
        }

        public Movie Get(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/movie/" + id.ToString()).Result;
            var movie = response.Content.ReadAsAsync<Movie>().Result;
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/movie/").Result;
            var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            return movies;
        }

        public HttpResponseMessage Update(Movie t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/movie/" + t.MovieId, t).Result;
            return response;
        }
    }
}