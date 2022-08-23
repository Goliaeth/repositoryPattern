using CustomerManagement.BusinessEntities;
using CustomerManagement.Repositories;

namespace CustomerManagement.IntegrationTests
{
    public class AddressRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new AddressRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var repository = new AddressRepository();
            var address = new Address
            {
                CustomerId = 1,
                AddressLine = "aaa",
                AddressLine2 = "bbb",
                AddressType = "Shipping",
                City = "Chicago",
                Country = "United States",
                PostalCode = "555655",
                State = "Some state"
            };
            var createdAddress = repository.Create(address);
            Assert.NotNull(createdAddress);
        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var repository = new AddressRepository();
            var readedAddress = repository.Read("1");
            Assert.NotNull(readedAddress);
        }

        [Fact]
        public void ShouldBeAbleToReadNonexistentAddress()
        {
            var repository = new AddressRepository();
            var readedAddress = repository.Read("1456456465");
            Assert.Null(readedAddress);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var repository = new AddressRepository();
            var address = new Address
            {
                CustomerId = 1,
                AddressLine = "aaa",
                AddressLine2 = "bbb",
                AddressType = "Shipping",
                City = "Chicago",
                Country = "United States",
                PostalCode = "555655",
                State = "Updated state info"
            };
            var updatedAddress = repository.Update(address);
            Assert.Equal(address.State, updatedAddress.State);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var repository = new AddressRepository();
            repository.Delete("3");
            var deletedAddress = repository.Read("3");
            Assert.Null(deletedAddress);
        }
    }
}
