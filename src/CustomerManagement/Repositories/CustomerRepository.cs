using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public void Create(Customer customer)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO [CustomerLib_DB].[s1].[Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)", connection);
            //var idParam = new SqlParameter("@Id", SqlDbType.Int)
            //{
            //    Value = customer.Id
            //};
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

            //command.Parameters.Add(idParam);
            command.Parameters.Add(firstNameParam);
            command.Parameters.Add(lastNameParam);
            command.Parameters.Add(phoneNumberParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(totalPurchasesAmountParam);

            command.ExecuteNonQuery();
        }

        public Customer Read(string customerId)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("SELECT * FROM [CustomerLib_DB].[s1].[Customers] WHERE id = @customerId", connection);
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

        public void Update(Customer customer)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("UPDATE [CustomerLib_DB].[s1].[Customers] SET PhoneNumber = @phoneNumber WHERE id = @customerId", connection);
            var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
            {
                Value = "4"
            };
            var phoneNumberParam = new SqlParameter("@phoneNumber", SqlDbType.NVarChar)
            {
                Value = customer.PhoneNumber
            };
            command.Parameters.Add(customerIdParam);
            command.Parameters.Add(phoneNumberParam);
            command.ExecuteNonQuery();

        }

        public void Delete(string customerId)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("DELETE FROM [CustomerLib_DB].[s1].[Customers] WHERE id = @customerId", connection);
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
