using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MovieShopDAL.BE;

namespace MovieShopAdminv2.Infrastructure
{
    public class OrderlineServiceGateway : IServiceGateway<Orderline>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Orderline t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/orderlines", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/orderlines/" + id.ToString()).Result;
            return response;
        }

        public Orderline Get(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orderlines" + id.ToString()).Result;
            var orderline = response.Content.ReadAsAsync<Orderline>().Result;
            return orderline;
        }

        public IEnumerable<Orderline> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/orderlines/").Result;
            var orderline = response.Content.ReadAsAsync<IEnumerable<Orderline>>().Result;
            return orderline;
        }

        public HttpResponseMessage Update(Orderline t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/orderlines/" + t.Id.ToString(), t).Result;
            return response;
        }
    }
}