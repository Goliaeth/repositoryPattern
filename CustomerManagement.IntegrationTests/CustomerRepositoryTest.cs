using CustomerManagement.BusinessEntities;
using CustomerManagement.Repositories;
using Xunit;

namespace CustomerManagement.IntegrationTests
{
    public class CustomerRepositoryTest
    {
        //public CustomerRepositoryFixture Fixture => new CustomerRepositoryFixture();
        
        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var repository = new CustomerRepository();
            var customer = new Customer
            {
                FirstName = "Vasiliy",
                LastName = "Ustugov",
                PhoneNumber = "99744556456",
                Email = "44566@gmail.com",
                TotalPurchasesAmount = 15
            };
            var createdCustomer = repository.Create(customer);
            Assert.NotNull(createdCustomer);
        }

        [Fact]
        public void ShouldNotBeAbleToCreateCustomer()
        {
            var repository = new CustomerRepository();
            var customer = new Customer
            {
                FirstName = "Petr",
                LastName = "Petrov",
                PhoneNumber = "99744556456",
                Email = "4456il.com",
                TotalPurchasesAmount = 15
            };
            var createdCustomer = repository.Create(customer);
            Assert.Null(createdCustomer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var repository = new CustomerRepository();
            var readedCustomer = repository.Read("4");
            Assert.NotNull(readedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToReadNonexistentCustomer()
        {
            var repository = new CustomerRepository();
            var readedCustomer = repository.Read("2");
            Assert.Null(readedCustomer);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repository = new CustomerRepository();
            var customer = new Customer
            {
                Id = 4,
                FirstName = "Petr",
                LastName = "Petrov",
                PhoneNumber = "98888888888",
                Email = "44566@gmail.com",
                TotalPurchasesAmount = 15
            };
            var updatedCustomer = repository.Update(customer);
            Assert.Equal(customer.PhoneNumber, updatedCustomer.PhoneNumber);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var repository = new CustomerRepository();
            repository.Delete("15");
            var deletedCustomer = repository.Read("15");
            Assert.Null(deletedCustomer);
        }

    }
    
    //public class CustomerRepositoryFixture
    //{
    //    public void DeleteAll()
    //    {
    //        var customerRepository = new CustomerRepository();
    //        customerRepository.DeleteAll();
    //    }
    //}
}