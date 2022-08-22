using CustomerManagement.BusinessEntities;
using CustomerManagement.Repositories;

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
                //Id = 109,
                FirstName = "Petr",
                LastName = "Petrov",
                PhoneNumber = "99744556456",
                Email = "44566@gmail.com",
                TotalPurchasesAmount = 15
            };
            repository.Create(customer);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var repository = new CustomerRepository();
            var readedCustomer = repository.Read("4");
        }

        [Fact]
        public void ShouldBeAbleToReadNonexistentCustomer()
        {
            var repository = new CustomerRepository();
            var readedCustomer = repository.Read("2");
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repository = new CustomerRepository();
            var customer = new Customer
            {
                FirstName = "Petr",
                LastName = "Petrov",
                PhoneNumber = "98888888888",
                Email = "44566@gmail.com",
                TotalPurchasesAmount = 15
            };
            repository.Update(customer);
            var updatedCustomer = repository.Read("4");
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