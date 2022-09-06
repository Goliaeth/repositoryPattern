using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagement.WebMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomersController()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomersController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: Customers
        public ActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            var customers = _customerRepository.GetAll();
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id, int? notesPage, int? addressesPage)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _customerRepository.Read(id.ToString());

            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.notesPage = notesPage;
            ViewBag.addressesPage = addressesPage;

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                _customerRepository.Create(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.Read(id.ToString());
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                _customerRepository.Update(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.Read(id.ToString());
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                _customerRepository.Delete(id.ToString());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
