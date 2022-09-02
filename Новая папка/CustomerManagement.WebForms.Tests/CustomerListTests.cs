using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CustomerManagement.WebForms.Tests
{
    public class CustomerListTests
    {
        [Fact]
        public void ShouldLoadCustomersFromDB()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.GetAll())
                .Returns(() => new List<Customer>() { new Customer(), new Customer() });
            var customerList = new CustomerList(customerRepositoryMock.Object);
            customerList.LoadCustomersFromDB();
            Assert.Equal(2, customerList._customerList.Count);
        }
    }
}