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
    public partial class AddressEdit : System.Web.UI.Page
    {
        private IRepository<Address> _addressRepository;
        public AddressEdit()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressEdit(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var addressIdReq = Request.QueryString["addressId"];
                var operation = Request.QueryString["operation"];
                var customerIdReq = Request.QueryString["customerId"];
                if (addressIdReq != null && operation == "edit")
                {
                    var address = _addressRepository.Read(addressIdReq);
                    addressLine.Text = address.AddressLine;
                    addressLine2.Text = address.AddressLine2;
                    addressType.Text = address.AddressType;
                    city.Text = address.City;
                    postalCode.Text = address.PostalCode;
                    state.Text = address.State;
                    country.Text = address.Country;
                }
                if (addressIdReq != null && operation == "delete")
                {
                    _addressRepository.Delete(addressIdReq);
                    Response.Redirect($"AddressesList.aspx?page=1&customerId={customerIdReq}");
                }
            }
        }

        public void onAddressSave(object sender, EventArgs e)
        {
            var address = new Address
            {
                CustomerId = int.Parse(Request.QueryString["customerId"]),
                AddressLine = addressLine.Text,
                 AddressLine2 = addressLine2.Text,
                 AddressType = addressType.Text,
                 City = city.Text,
                 PostalCode = postalCode.Text,
                 State = state.Text,
                 Country = country.Text,
            };
            if (Request.QueryString["addressId"] == null)
            {
                var createdNote = _addressRepository.Create(address);
            }
            else
            {
                address.Id = int.Parse(Request.QueryString["addressId"]);
                _addressRepository.Update(address);
            }
            Response.Redirect($"AddressesList.aspx?page=1&customerId={Request.QueryString["customerId"]}");
        }
    }
}