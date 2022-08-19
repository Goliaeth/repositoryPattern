using CustomerManagement.Repositories;

namespace CustomerManagement.IntegrationTests
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateRepository()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository);
        }
    }
}