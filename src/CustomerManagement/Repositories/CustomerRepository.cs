using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public Customer Create(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO [s1].[Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) output INSERTED.ID VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)", connection);
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
                    var newCustomerId = command.ExecuteScalar();
                    customer.Id = (int)newCustomerId;
                }
                catch (Exception ex)
                {
                    customer = null;
                    Console.WriteLine(ex);
                }
                
            }
            return customer;
        }

        public Customer Read(string customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Customers] WHERE id = @customerId", connection);
                var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
                {
                    Value = customerId
                };
                command.Parameters.Add(customerIdParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            TotalPurchasesAmount = reader.GetDecimal(reader.GetOrdinal("TotalPurchasesAmount"))
                        };
                    }
                    return null;
                }
                    
            }
                
        }

        public Customer Update(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [s1].[Customers] SET FirstName=@FirstName, LastName=@LastName, PhoneNumber=@PhoneNumber, Email=@Email, TotalPurchasesAmount=@TotalPurchasesAmount OUTPUT INSERTED.ID WHERE id = @CustomerId", connection);
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customer.Id
                };
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
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(phoneNumberParam);
                command.Parameters.Add(emailParam);
                command.Parameters.Add(totalPurchasesAmountParam);

                try
                {
                    var updatedCustomerId = command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    customer = null;
                    Console.WriteLine(ex);
                }
            }
            return customer;
        }

        public void Delete(string customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [s1].[Notes] WHERE CustomerID = @customerId; DELETE FROM [s1].[Addresses] WHERE CustomerID = @customerId; DELETE FROM [s1].[Customers] WHERE id = @customerId", connection);
                var customerIdParam = new SqlParameter("@customerId", SqlDbType.Int)
                {
                    Value = customerId
                };
                command.Parameters.Add(customerIdParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Customers]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            TotalPurchasesAmount = reader["TotalPurchasesAmount"] == DBNull.Value ? null : (decimal?)reader["TotalPurchasesAmount"],
                        });
                    }
                    
                }

            }

            return customers;

        }

        public List<Customer> Read(int offset, int count)
        {
            var customers = new List<Customer>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Customers] ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @Count ROWS ONLY", connection);
                var offsetParam = new SqlParameter("@Offset", SqlDbType.Int)
                {
                    Value = offset,
                };
                var countParam = new SqlParameter("@Count", SqlDbType.Int)
                {
                    Value = count,
                };
                command.Parameters.Add(offsetParam);
                command.Parameters.Add(countParam);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            TotalPurchasesAmount = reader["TotalPurchasesAmount"] == DBNull.Value ? null : (decimal?)reader["TotalPurchasesAmount"],
                        });
                    }
                    
                }

            }
            return customers;
        }

        public List<Customer> Read(int offset, int count, string customerId)
        {
            var customers = new List<Customer>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Customers] WHERE CustomerID = @CustomerId ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @Count ROWS ONLY", connection);
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId,
                };
                var offsetParam = new SqlParameter("@Offset", SqlDbType.Int)
                {
                    Value = offset,
                };
                var countParam = new SqlParameter("@Count", SqlDbType.Int)
                {
                    Value = count,
                };
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(offsetParam);
                command.Parameters.Add(countParam);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            TotalPurchasesAmount = reader["TotalPurchasesAmount"] == DBNull.Value ? null : (decimal?)reader["TotalPurchasesAmount"],
                        });
                    }

                }

            }
            return customers;
        }

        public int Count()
        {
            int count;
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM [s1].[Customers]", connection);
                try
                {
                    count = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    count = 0;
                    Console.WriteLine(ex);
                }

            }
            return count;
        }


    }

}
