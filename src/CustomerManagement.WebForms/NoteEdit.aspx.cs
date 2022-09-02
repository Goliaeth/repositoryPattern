using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerManagement.WebForms
{
    public partial class NoteEdit : System.Web.UI.Page
    {
        private IRepository<Note> _noteRepository;
        public NoteEdit()
        {
            _noteRepository = new NoteRepository();
        }

        public NoteEdit(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var noteIdReq = Request.QueryString["noteId"];
                var operation = Request.QueryString["operation"];
                var customerIdReq = Request.QueryString["customerId"];
                if (noteIdReq != null && operation == "edit")
                {
                    var note = _noteRepository.Read(noteIdReq);
                    noteTextArea.Text = note.NoteText;
                }
                if (noteIdReq != null && operation == "delete")
                {
                    _noteRepository.Delete(noteIdReq);
                    Response.Redirect($"NotesList.aspx?page=1&customerId={customerIdReq}");
                }
            }
        }

        public void onNoteSave(object sender, EventArgs e)
        {
            var note = new Note
            {
                CustomerId = int.Parse(Request.QueryString["customerId"]),
                NoteText = noteTextArea.Text,
            };
            if (Request.QueryString["noteId"] == null)
            {
                var createdNote = _noteRepository.Create(note);
            }
            else
            {
                note.Id = int.Parse(Request.QueryString["noteId"]);
                _noteRepository.Update(note);
            }
            Response.Redirect($"NotesList.aspx?page=1&customerId={Request.QueryString["customerId"]}");
        }
    }
}