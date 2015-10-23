using MovieShopDAL;
using MovieShopDAL.BE;
using MovieShopDAL.Repositories;
using MovieShopUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShopUser.Controllers
{
    public class ShoppingCartController : Controller
    {

        private IShoppingCartModel cartModel;
        DALFacade DF = new DALFacade();

        public ShoppingCartController()
        {
            IRepository<Movie> repository = new DALFacade().MovieRepository;
            this.cartModel = new ShoppingCartModel(repository);
        }

        // The Initialize() method is invoked just after the constructor. It is
        // used to initialize data that is not available when the constructor is
        // executed.
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["cart"] == null)
                Session["cart"] = new List<ShoppingCartItem>();

            cartModel.Items = (List<ShoppingCartItem>)Session["cart"];
        }

        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            return View(cartModel);
        }

        // GET: /ShoppingCart/Add
        public ActionResult Add(int id)
        {
            cartModel.Add(id);
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Clear()
        {
            Session["cart"] = null;
            return RedirectToAction("Index", "Movies");
        }

        // Child action: returns the number of items in the shopping cart
        [ChildActionOnly]
        public ActionResult NoOfItems()
        {
            return Content("[" + cartModel.NoOfItems + "]");
        }

        public ActionResult AmountPlus(int id)
        {
            List<ShoppingCartItem> cartItems = (List<ShoppingCartItem>)Session["cart"];
            ShoppingCartItem cartItem = cartItems.Find(item => item.MovieId == id);

            //if (cartItem == null)
            //{
            //    Movie movie = DF.MovieRepository.Get(id);
            //    cartItem = new ShoppingCartItem { Id = movie.MovieId, Title = movie.Title, UnitPrice = (decimal)movie.Price, Quantity = 1 };
            //    cartItems.Add(cartItem);
            //}
            //else
                cartItem.Quantity++;

            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult AmountMinus(int id)
        {
            List<ShoppingCartItem> cartItems = (List<ShoppingCartItem>)Session["cart"];
            ShoppingCartItem cartItem = cartItems.Find(item => item.MovieId == id);

            if (cartItem.Quantity == 1)
            {
                cartItems.Remove(cartItem);
            }
            else
                cartItem.Quantity--;

            return RedirectToAction("Index", "ShoppingCart");
        }
       
    }
}