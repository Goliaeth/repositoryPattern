using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public Address Create(Address address)
        {
            int newAddressId = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO [s1].[Addresses] (CustomerID, AddressLine, AddressLine2, AddressType, City, Country, PostalCode, State) VALUES (@CustomerID, @AddressLine, @AddressLine2, @AddressType, @City, @Country, @PostalCode, @State)", connection);
                var customerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Value = address.CustomerId
                };
                var addressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine
                };
                var addressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = address.AddressLine2
                };
                var addressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 20)
                {
                    Value = address.AddressType
                };
                var cityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = address.City
                };
                var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar, 20)
                {
                    Value = address.Country
                };
                var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = address.PostalCode
                };
                var stateParam = new SqlParameter("@State", SqlDbType.NVarChar, 20)
                {
                    Value = address.State
                };

                command.Parameters.Add(customerIDParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(countryParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);

                try
                {
                    newAddressId = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                address.Id = (int)newAddressId;
                return address;
            }
                
        }

        public Address Read(string addressId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Addresses] WHERE id = @addressId", connection);
                var addressIdParam = new SqlParameter("@addressId", SqlDbType.Int)
                {
                    Value = addressId
                };
                command.Parameters.Add(addressIdParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Address
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            Country = reader["Country"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString()
                        };
                    }
                    return null;
                }
                    
            }
            
        }

        public Address Update(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [s1].[Addresses] SET State = @state WHERE id = @addressId", connection);
                var addressIdParam = new SqlParameter("@addressId", SqlDbType.Int)
                {
                    Value = address.Id
                };
                var stateParam = new SqlParameter("@state", SqlDbType.NVarChar)
                {
                    Value = address.State
                };
                command.Parameters.Add(addressIdParam);
                command.Parameters.Add(stateParam);
                command.ExecuteNonQuery();

                return address;
            }
                
        }

        public void Delete(string addressId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [s1].[Addresses] WHERE id = @addressId", connection);
                var addressIdParam = new SqlParameter("@addressId", SqlDbType.Int)
                {
                    Value = addressId
                };
                command.Parameters.Add(addressIdParam);
                command.ExecuteNonQuery();
            }
                
        }


    }
}
