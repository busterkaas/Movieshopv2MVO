using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDAL;
using MovieShopDAL.BE;
using MovieShopDTO.Converter;
using MovieShopDTO.ModelDTO;

namespace MovieShop_Rest.Controllers
{
    public class CustomersController : ApiController
    {
        DALFacade df = new DALFacade();

        // GET: api/Customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            var customers = df.CustomerRepository.GetAll();
            return new CustomerConverter().Convert(customers);
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = df.CustomerRepository.Get(id);
            var customerDto = new CustomerConverter().Convert(customer);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customerDto);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            try
            {
                df.CustomerRepository.Edit(new CustomerConverter().Reverse(customer));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            df.CustomerRepository.Add(new CustomerConverter().Reverse(customer));

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = df.CustomerRepository.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            df.CustomerRepository.Remove(customer.CustomerId);


            return Ok(customer);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CustomerExists(int id)
        //{
        //    return db.Customers.Count(e => e.CustomerId == id) > 0;
        //}
    }
}