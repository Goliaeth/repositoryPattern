using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public Customer Create(Customer customer)
        {
            Int32 newCustomerId = 0;
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO [s1].[Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)", connection);
            var firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
            {
                Value = customer.FirstName
            };
            var lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
            {
                Value = customer.LastName
            };
            var phoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
            {
                Value = customer.PhoneNumber
            };
            var emailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 50)
            {
                Value = customer.Email
            };
            var totalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money)
            {
                Value = customer.TotalPurchasesAmount
            };

            command.Parameters.Add(firstNameParam);
            command.Parameters.Add(lastNameParam);
            command.Parameters.Add(phoneNumberParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(totalPurchasesAmountParam);
            
            try
            {
                newCustomerId = (Int32)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            customer.Id = (int)newCustomerId;
            return customer;
        }

        public Customer Read(string customerId)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("SELECT * FROM [s1].[Customers] WHERE id = @customerId", connection);
            var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
            {
                Value = customerId
            };
            command.Parameters.Add(customerIdParam);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Customer
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    TotalPurchasesAmount = reader.GetDecimal(reader.GetOrdinal("TotalPurchasesAmount"))
                };
            }
            return null;
        }

        public Customer Update(Customer customer)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("UPDATE [s1].[Customers] SET PhoneNumber = @phoneNumber WHERE id = @customerId", connection);
            var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
            {
                Value = customer.Id
            };
            var phoneNumberParam = new SqlParameter("@phoneNumber", SqlDbType.NVarChar)
            {
                Value = customer.PhoneNumber
            };
            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(phoneNumberParam);
            command.ExecuteNonQuery();

            return customer;

        }

        public void Delete(string customerId)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("DELETE FROM [s1].[Customers] WHERE id = @customerId", connection);
            var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
            {
                Value = customerId
            };
            command.Parameters.Add(customerIdParam);
            command.ExecuteNonQuery();
        }

        //public void DeleteAll()
        //{
        //    using var connection = GetConnection();
        //    connection.Open();
        //    var command = new SqlCommand(
        //        "DELETE FROM [CustomerLib_DB].[s1].[Customers]", connection);
        //    command.ExecuteNonQuery();
        //}
    }
}
