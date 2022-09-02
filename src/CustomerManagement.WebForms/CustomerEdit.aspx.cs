using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerManagement.WebForms
{
    public partial class CustomerEdit : System.Web.UI.Page
    {
        private IRepository<Customer> _customerRepository;
        public CustomerEdit()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerEdit(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var customerIdReq = Request.QueryString["customerId"];
                var operation = Request.QueryString["operation"];
                if (customerIdReq != null && operation == "edit")
                {
                    var customer = _customerRepository.Read(customerIdReq);
                    customerFirstName.Text = customer.FirstName;
                    customerLastName.Text = customer.LastName;
                    customerPhoneNumber.Text = customer.PhoneNumber;
                    customerEmail.Text = customer.Email;
                    customerTotalPurchasesAmount.Text = customer.TotalPurchasesAmount.ToString();
                }
                if (customerIdReq != null && operation == "delete")
                {
                    _customerRepository.Delete(customerIdReq);
                    Response.Redirect("CustomerList.aspx");
                }
            }
            
        }

        public void onClickSave(object sender, EventArgs e)
        {
            decimal num;
            decimal.TryParse(customerTotalPurchasesAmount?.Text, out num);
            var customer = new Customer
            {
                FirstName = customerFirstName?.Text,
                LastName = customerLastName?.Text,
                PhoneNumber = customerPhoneNumber?.Text,
                Email = customerEmail?.Text,
                TotalPurchasesAmount = num,
            };
            if (Request.QueryString["customerId"] == null)
            {
                var createdCustomer = _customerRepository.Create(customer);
            } else
            {
                customer.Id = int.Parse(Request.QueryString["customerId"]);
                _customerRepository.Update(customer);
            }
            Response.Redirect("CustomerList.aspx");
            
        }
    }
}