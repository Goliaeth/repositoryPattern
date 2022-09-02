using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using System;
using System.Collections.Generic;

namespace CustomerManagement.WebForms
{
    public partial class NotesList : System.Web.UI.Page
    {
        const int MaxRecords = 3;
        protected int _page;
        protected int _maxPage;
        protected List<Note> _noteList;
        protected Customer _currentCustomer;

        private IRepository<Note> _noteRepository;
        private IRepository<Customer> _customerRepository;
        public NotesList()
        {
            _noteRepository = new NoteRepository();
            _customerRepository = new CustomerRepository();
        }

        public NotesList(IRepository<Note> noteRepository, IRepository<Customer> customerRepository)
        {
            _noteRepository = noteRepository;
            _customerRepository = customerRepository;
        }

        public void LoadNotesFromDB()
        {
            var customerIdReq = Request.QueryString["customerId"];
            if (customerIdReq == null) Response.Redirect($"CustomerList.aspx");
            _currentCustomer = _customerRepository.Read(customerIdReq);

            var pageReq = Request.QueryString["page"];
            _page = string.IsNullOrEmpty(pageReq) ? 1 : int.Parse(pageReq);

            int offset = (_page - 1) * MaxRecords;
            _noteList = _noteRepository.Read(offset, MaxRecords, customerIdReq);

            _maxPage = (_noteRepository.Count() + MaxRecords - 1) / MaxRecords;

            if (_page == 1)
            {
                buttonPrev.Enabled = false;
                buttonFirst.Enabled = false;
            }
            if (_page == _maxPage)
            {
                buttonNext.Enabled = false;
                buttonLast.Enabled = false;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNotesFromDB();
        }

        public void onClickPrevPage(object sender, EventArgs e)
        {
            Response.Redirect($"NotesList.aspx?page={_page - 1}&customerId={Request.QueryString["customerId"]}");
        }

        public void onClickNextPage(object sender, EventArgs e)
        {
            Response.Redirect($"NotesList.aspx?page={_page + 1}&customerId={Request.QueryString["customerId"]}");
        }

        public void onClickFirstPage(object sender, EventArgs e)
        {
            Response.Redirect($"NotesList.aspx?page={1}&customerId={Request.QueryString["customerId"]}");
        }

        public void onClickLastPage(object sender, EventArgs e)
        {
            Response.Redirect($"NotesList.aspx?page={_maxPage}&customerId={Request.QueryString["customerId"]}");
        }
    }
}