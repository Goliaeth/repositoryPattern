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
    public partial class AddressesList : System.Web.UI.Page
    {
        const int MaxRecords = 3;
        protected int _page;
        protected int _maxPage;
        protected List<Address> _addressList;
        protected Customer _currentCustomer;

        private IRepository<Address> _addressRepository;
        private IRepository<Customer> _customerRepository;
        public AddressesList()
        {
            _addressRepository = new AddressRepository();
            _customerRepository = new CustomerRepository();
        }

        public AddressesList(IRepository<Address> addressRepository, IRepository<Customer> customerRepository)
        {
            _addressRepository = addressRepository;
            _customerRepository = customerRepository;
        }

        public void LoadAddressesFromDB()
        {
            var customerIdReq = Request.QueryString["customerId"];
            if (customerIdReq == null) Response.Redirect($"CustomerList.aspx");
            _currentCustomer = _customerRepository.Read(customerIdReq);

            var pageReq = Request.QueryString["page"];
            _page = string.IsNullOrEmpty(pageReq) ? 1 : int.Parse(pageReq);

            int offset = (_page - 1) * MaxRecords;
            _addressList = _addressRepository.Read(offset, MaxRecords, customerIdReq);

            _maxPage = (_addressRepository.Count() + MaxRecords - 1) / MaxRecords;

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
            LoadAddressesFromDB();
        }

        public void onClickPrevPage(object sender, EventArgs e)
        {
            Response.Redirect($"AddressesList.aspx?page={_page - 1}&customerId={Request.QueryString["customerId"]}");
        }

        public void onClickNextPage(object sender, EventArgs e)
        {
            Response.Redirect($"AddressesList.aspx?page={_page + 1}&customerId={Request.QueryString["customerId"]}");
        }

        public void onClickFirstPage(object sender, EventArgs e)
        {
            Response.Redirect($"AddressesList.aspx?page={1}&customerId={Request.QueryString["customerId"]}");
        }

        public void onClickLastPage(object sender, EventArgs e)
        {
            Response.Redirect($"AddressesList.aspx?page={_maxPage}&customerId={Request.QueryString["customerId"]}");
        }
    }
}