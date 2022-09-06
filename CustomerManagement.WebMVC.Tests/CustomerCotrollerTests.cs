using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using CustomerManagement.WebMVC.Controllers;
using Moq;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace CustomerManagement.WebMVC.Tests
{
    public class CustomerCotrollerTests
    {
        [Fact]
        public void ShouldCreateCustomerController()
        {
            var customerController = new CustomersController();
            Assert.NotNull(customerController);
        }

        [Fact]
        public void ShouldReturnListOfCustomers()
        {
            var controller = new CustomersController();
            var customersResult = controller.Index(1);
            var customersView = customersResult as ViewResult;
            var customersModel = customersView.Model as IPagedList<Customer>;

            Assert.Equal(5, customersModel.Count);
        }

        [Fact]
        public void ShouldCreateCustomer()
        {
            var customersControllerMock = new Mock<IRepository<Customer>>();
            var customerController = new CustomersController(customersControllerMock.Object);
            customerController.Create();

            var result = customerController.Create(new Customer
            {
                FirstName = "Vasiliy",
                LastName = "Ustugov",
                PhoneNumber = "99744556456",
                Email = "44566@gmail.com",
                TotalPurchasesAmount = 15
            }) as RedirectToRouteResult;
            Assert.NotNull(result);
        }

        //[Fact]
        //public void ShouldNotCreateCustomer()
        //{
        //    var customersControllerMock = new Mock<IRepository<Customer>>();
        //    var customerController = new CustomersController(customersControllerMock.Object);
        //    customerController.Create();

        //    var result = customerController.Create(new Customer
        //    {
        //        FirstName = "Vasiliy",
        //        LastName = "sdfsddd",
        //        PhoneNumber = "99744556456",
        //        Email = "fdgdfg",
        //        TotalPurchasesAmount = 15
        //    }) as ViewResult;
        //    Assert.Null(result);
        //}

        [Fact]
        public void ShouldDeleteCustomer()
        {
            //Customer customer = new Customer()
            //{
            //    Id = 1,
            //    LastName = "LastName"
            //};
            var customersControllerMock = new Mock<IRepository<Customer>>();
            //customersControllerMock.Setup(x => x.Delete("16"));
            
            var customerController = new CustomersController(customersControllerMock.Object);
 
            var result = customerController.Delete(16) as RedirectToRouteResult;

            //customersControllerMock.Verify(x => x.Delete("16"), Times.Once);

            Assert.NotNull(result);

            //if (result?.RouteValues.Values != null) Assert.Contains("Index", result.RouteValues.Values);
        }

        [Fact]
        public void ShouldEditCustomer()
        {
            var customersControllerMock = new Mock<IRepository<Customer>>();
            var customerController = new CustomersController(customersControllerMock.Object);

            var result = customerController.Edit(15);

            Assert.NotNull(result);
        }
    }
}