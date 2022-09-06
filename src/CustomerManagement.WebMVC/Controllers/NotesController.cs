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
    public class NotesController : Controller
    {
        private readonly IDepRepository<Note> _noteRepository;

        public NotesController()
        {
            _noteRepository = new NoteRepository();
        }

        public NotesController(IDepRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: Notes
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Customers", null);
        }

        // GET: Notes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notes/Create
        public ActionResult Create(int customerId)
        {
            ViewBag.customerId = customerId;
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        public ActionResult Create(int customerId, Note note)
        {
            try
            {
                // TODO: Add insert logic here
                note.CustomerId = customerId;
                _noteRepository.Create(note);

                return RedirectToAction("Details", "Customers", new { id = customerId, notesPage = 1, addressesPage = 1 });
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int noteId, int? customerId)
        {
            var note = _noteRepository.Read(noteId.ToString());
            ViewBag.customerId = customerId;
            return View(note);
        }

        // POST: Notes/Edit/5
        [HttpPost]
        public ActionResult Edit(int noteId, int? customerId, Note note)
        {
            try
            {
                // TODO: Add update logic here
                _noteRepository.Update(note);
                return RedirectToAction("Details", "Customers", new { id = customerId, notesPage = 1, addressesPage = 1 });
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int noteId, int? customerId)
        {
            var note = _noteRepository.Read(noteId.ToString());
            ViewBag.customerId = customerId;
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost]
        public ActionResult Delete(int noteId, int? customerId, Note note)
        {
            try
            {
                // TODO: Add delete logic here
                _noteRepository.Delete(noteId.ToString());

                return RedirectToAction("Details", "Customers", new { id = customerId, notesPage = 1, addressesPage = 1 });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PartialList(int customerId, int? notesPage, int? addressesPage)
        {
            int pageNumber = notesPage ?? 1;
            int pageSize = 5;
            var notes = _noteRepository.GetAllById(customerId.ToString());
            ViewBag.customerId = customerId;
            ViewBag.addressesPage = addressesPage;
            return PartialView(notes.ToPagedList(pageNumber, pageSize));
        }

    }
}
