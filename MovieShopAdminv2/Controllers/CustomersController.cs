﻿using MovieShopDAL;
using MovieShopDAL.BE;
using MovieShopDAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MovieShop.Controllers
{
    public class CustomersController : Controller
    {
        private IRepository<Customer> custRepo = new DALFacade().CustomerRepository;

        // GET: Customers
        public ActionResult Index()
        {
            var customers = custRepo.GetAll();
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customers = custRepo.Get(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] Customer customer)
        {
            if (!Validate(customer))
            {
                return RedirectToAction("Create");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    custRepo.Add(customer);
                    return RedirectToAction("Index");
                }
                return View(customer);
            }

        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customers = custRepo.Get(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                custRepo.Edit(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customers = custRepo.Get(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            custRepo.Remove(id);
            return RedirectToAction("Index");
        }

        private bool Validate(Customer cus)
        {
            List<Customer> customers = custRepo.GetAll().ToList();
            Customer customer = customers.Find(c => c.Email == cus.Email);
            if (customer != null) { return false; } else { return true; }
        }

    }
}
