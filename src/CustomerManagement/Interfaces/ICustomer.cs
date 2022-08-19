using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Interfaces
{
    public interface ICustomer<Customer>
    {
        void Create(Customer customer);
        Customer Read(string customerId);
        void Update(Customer customer);
        void Delete(string customerId);
    }
}
