
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MovieShopAdminv2.Infrastructure;
using MovieShopDAL.BE;
using MovieShopDAL;
using MovieShopDAL.Repositories;

namespace MovieShopAdminv2.Controllers
{
    public class OrdersController : Controller
    {
        //private IRepository<Order> orderRepo = new DALFacade().OrderRepository;
        //private IRepository<Movie> movieRepo = new DALFacade().MovieRepository;
        //private IRepository<Customer> customerRepo = new DALFacade().CustomerRepository;

        CustomerServiceGateway csg = new CustomerServiceGateway();
        OrderServiceGateway osg = new OrderServiceGateway();
        MovieServiceGateway msg = new MovieServiceGateway();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = osg.GetAll().ToList();
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            Order order = osg.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(csg.GetAll(), "CustomerId", "FirstName");
            ViewBag.MovieId = new SelectList(msg.GetAll(), "MovieId", "Title");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,Date,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                osg.Create(order);
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(csg.GetAll(), "CustomerId", "FirstName", order.Customer.CustomerId);
            //ViewBag.MovieId = new SelectList(movieRepo.GetAll(), "MovieId", "Title", order.Movie.MovieId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = osg.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(csg.GetAll(), "CustomerId", "FirstName", order.Customer.CustomerId);
            //ViewBag.MovieId = new SelectList(movieRepo.GetAll(), "MovieId", "Title", order.Movie.MovieId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,Date,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                osg.Update(order);
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(csg.GetAll(), "CustomerId", "FirstName", order.Customer.CustomerId);
            //ViewBag.MovieId = new SelectList(movieRepo.GetAll(), "MovieId", "Title", order.Movie.MovieId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            Order order = osg.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            osg.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
