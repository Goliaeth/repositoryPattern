using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.WebForms.Tests
{
    public class CustomerEditTests
    {
        [Fact]
        public void ShouldEditCustomer()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            var customerEdit = new CustomerEdit(customerRepositoryMock.Object);
            customerEdit.onClickSave(this, EventArgs.Empty);
            customerRepositoryMock.Verify(x => x.Create(It.IsAny<Customer>()));
        }
    }
}
