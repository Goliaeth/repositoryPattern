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
    public class AddressesController : Controller
    {
        private readonly IDepRepository<Address> _addressRepository;

        public AddressesController()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressesController(IDepRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: Addresses
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Customers", null);
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Addresses/Create
        public ActionResult Create(int customerId)
        {
            ViewBag.customerId = customerId;
            return View();
        }

        // POST: Addresses/Create
        [HttpPost]
        public ActionResult Create(int customerId, Address address)
        {
            try
            {
                // TODO: Add insert logic here
                address.CustomerId = customerId;
                _addressRepository.Create(address);

                return RedirectToAction("Details", "Customers", new { id = customerId, notesPage = 1, addressesPage = 1 });
            }
            catch
            {
                return View();
            }
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int addressId, int? customerId)
        {
            var address = _addressRepository.Read(addressId.ToString());
            ViewBag.customerId = customerId;
            return View(address);
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        public ActionResult Edit(int addressId, int? customerId, Address address)
        {
            try
            {
                // TODO: Add update logic here
                _addressRepository.Update(address);

                return RedirectToAction("Details", "Customers", new { id = customerId, notesPage = 1, addressesPage = 1 });
            }
            catch
            {
                return View();
            }
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int addressId, int? customerId)
        {
            var address = _addressRepository.Read(addressId.ToString());
            ViewBag.customerId = customerId;
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        public ActionResult Delete(int addressId, int? customerId, Address address)
        {
            try
            {
                // TODO: Add delete logic here
                _addressRepository.Delete(addressId.ToString());

                return RedirectToAction("Details", "Customers", new { id = customerId, notesPage = 1, addressesPage = 1 });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PartialList(int customerId, int? notesPage, int? addressesPage)
        {
            int pageNumber = addressesPage ?? 1;
            int pageSize = 5;
            var notes = _addressRepository.GetAllById(customerId.ToString());
            ViewBag.customerId = customerId;
            ViewBag.notesPage = notesPage;
            return PartialView(notes.ToPagedList(pageNumber, pageSize));
        }

    }
}
