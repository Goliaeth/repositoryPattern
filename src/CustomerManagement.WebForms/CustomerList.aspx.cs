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
    public partial class CustomerList : System.Web.UI.Page
    {
        const int MaxRecords = 10;
        protected int _page;
        protected int _maxPage;
        public List<Customer> _customerList;

        private IRepository<Customer> _customerRepository;
        public CustomerList()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerList(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //public List<Customer> Customers { get; set; }

        public void LoadCustomersFromDB()
        {
            //Customers = _customerRepository.GetAll();
            string pageString = Request.QueryString["page"];
            _page = string.IsNullOrEmpty(pageString) ? 1 : int.Parse(pageString);

            int offset = (_page - 1) * MaxRecords;
            _customerList = _customerRepository.Read(offset, MaxRecords);

            _maxPage = (_customerRepository.Count() + MaxRecords - 1) / MaxRecords;

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
            LoadCustomersFromDB();
        }

        //public void onClickDelete(object sender, EventArgs e)
        //{
        //    //_customerRepository.Delete();
        //}

        public void onClickPrevPage(object sender, EventArgs e)
        {
            Response.Redirect($"CustomerList.aspx?page={_page - 1}");
        }

        public void onClickNextPage(object sender, EventArgs e)
        {
            Response.Redirect($"CustomerList.aspx?page={_page + 1}");
        }

        public void onClickFirstPage(object sender, EventArgs e)
        {
            Response.Redirect($"CustomerList.aspx?page={1}");
        }

        public void onClickLastPage(object sender, EventArgs e)
        {
            Response.Redirect($"CustomerList.aspx?page={_maxPage}");
        }
    }
}