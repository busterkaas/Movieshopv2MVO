using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MovieShopDAL.BE;

namespace MovieShopAdminv2.Infrastructure
{
    public class CustomerServiceGateway : IServiceGateway<Customer>
    {
        ServiceGateway sg = new ServiceGateway();
        public HttpResponseMessage Create(Customer t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/customers", t).Result;
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.DeleteAsync("api/customers/" + id).Result;
            return response;
        }

        public Customer Get(int id)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/customers/" + id.ToString()).Result;
            var customer = response.Content.ReadAsAsync<Customer>().Result;
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.GetAsync("api/customers/").Result;
            var customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return customers;
        }

        public HttpResponseMessage Update(Customer t)
        {
            HttpClient client = sg.GetHttpClient();
            HttpResponseMessage response = client.PutAsJsonAsync("api/customers/" + t.CustomerId.ToString(), t).Result;
            return response;
        }
    }
}