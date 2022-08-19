
using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : ICustomer<Customer>
    {
        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(string customerId)
        {
            throw new NotImplementedException();
        }

        public Customer Read(string customerId)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
