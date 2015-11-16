using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;

namespace MovieShopAdminv2.Infrastructure
{
    public class ServiceGateway
    {
        public HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            string baseAddress = WebConfigurationManager.AppSettings["MovieShop_RestApiBaseAddress"];
            //client.BaseAddress = new Uri("http://localhost:2102/");
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
            );
            return client;
        }
    }
}