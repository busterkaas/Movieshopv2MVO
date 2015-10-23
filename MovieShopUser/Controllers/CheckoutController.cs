using MovieShopDAL;
using MovieShopDAL.BE;
using MovieShopUser.Models;
using MovieShopUser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopUser.Controllers
{
    public class CheckoutController : Controller
    {
        DALFacade df = new DALFacade();
        CustomerCart customerCart;


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValidateFormer()
        {
            string customerEmail = Request.Form["cusEmail"];
            List<Customer> customers = df.CustomerRepository.GetAll().ToList();
            Customer savedCustomer = customers.Find(c => c.Email == customerEmail);
            if (savedCustomer == null)
            {
                return RedirectToAction("Index", "Checkout");
            }
            else
            {
                return RedirectToAction("Confirmation", "Checkout", savedCustomer);
            }
        }

        [HttpPost]
        public ActionResult CustomerResult(Customer cus)
        {

            if (!Validate(cus))
            {
                return RedirectToAction("Index", "Checkout");
            }
            else
            {
                df.CustomerRepository.Add(cus);
                List<Customer> customers = df.CustomerRepository.GetAll().ToList();
                Customer finalCus = customers.Find(c => c.Email == cus.Email);

                return RedirectToAction("Confirmation", "Checkout", finalCus);
            }


            //string customerEmail = Request.Form["cusEmail"];
            //List<Customer> customers = df.CustomerRepository.GetAll().ToList();
            //Customer savedCustomer = customers.Find(c => c.Email == customerEmail);

            //if (savedCustomer == null)
            //{

            //    string email = Request.Form["email"];
            //    string firstName = Request.Form["firstName"];
            //    string lastName = Request.Form["lastName"];
            //    string street = Request.Form["street"];
            //    string streetNr = Request.Form["streetNr"];
            //    string city = Request.Form["city"];
            //    int zip = Int32.Parse(Request.Form["zipcode"]);

            //    Customer newCustomer = new Customer { Email=email, FirstName=firstName,LastName=lastName,StreetName=street,HouseNr=streetNr,City=city,ZipCode=zip };
            //    df.CustomerRepository.Add(newCustomer);
            //    customers = df.CustomerRepository.GetAll().ToList();
            //    Customer finalCus = customers.Find(c => c.Email == customerEmail);

            //    return RedirectToAction("Confirmation", "Checkout", finalCus);
            //}
            //else
            //{
            //    return RedirectToAction("Confirmation", "Checkout", savedCustomer);
            //}
        }

        private bool Validate(Customer cus)
        {
            List<Customer> customers = df.CustomerRepository.GetAll().ToList();
            Customer customer = customers.Find(c => c.Email == cus.Email);
            if (customer != null) { return false; } else { return true; }
        }

        // GET: Checkout

        public ActionResult Confirmation(Customer cus)
        {
            List<ShoppingCartItem> cartItems = (List<ShoppingCartItem>)Session["cart"];
            customerCart = new CustomerCart();
            customerCart.setCartItems(cartItems);
            customerCart.setCustomer(cus);

            
            Session["cont"] = customerCart;
            



            return View(customerCart);
        }

        public ActionResult Complete()
        {
            CustomerCart cc = (CustomerCart)Session["cont"];

          
            Order order = new Order { CustomerId = cc.Customer.CustomerId, Date = DateTime.Now };

            df.OrderRepository.Add(order);
            //List<Order> orders = df.OrderRepository.GetAll().ToList();
            //Order finalOrder = orders.FindLast(o);
            foreach(ShoppingCartItem item in cc.CartItems.ToList())
            {
                Orderline ol = new Orderline { Amount = item.Quantity, MovieId = item.MovieId, OrderId = order.OrderId };
                df.OrderlineRepository.Add(ol);
                
            }
            return View();
        }
    }
}