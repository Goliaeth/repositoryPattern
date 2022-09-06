using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class AddressRepository : BaseRepository, IDepRepository<Address>
    {
        public Address Create(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO [s1].[Addresses] (CustomerID, AddressLine, AddressLine2, AddressType, City, Country, PostalCode, State) output INSERTED.ID VALUES (@CustomerID, @AddressLine, @AddressLine2, @AddressType, @City, @Country, @PostalCode, @State)", connection);
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
                    var newAddressId = (int)command.ExecuteScalar();
                    address.Id = (int)newAddressId;
                }
                catch (Exception ex)
                {
                    address = null;
                    Console.WriteLine(ex.Message);
                }
                
            }
            return address;

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
                var command = new SqlCommand("UPDATE [s1].[Addresses] SET AddressLine=@AddressLine, AddressLine2=@AddressLine2, AddressType=@AddressType, City=@City, Country=@Country, PostalCode=@PostalCode, State=@State OUTPUT INSERTED.ID WHERE id = @addressId", connection);
                var addressIdParam = new SqlParameter("@addressId", SqlDbType.Int)
                {
                    Value = address.Id
                };
                var addressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar)
                {
                    Value = address.AddressLine
                };
                var addressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar)
                {
                    Value = address.AddressLine2
                };
                var addressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar)
                {
                    Value = address.AddressType
                };
                var cityParam = new SqlParameter("@City", SqlDbType.NVarChar)
                {
                    Value = address.City
                };
                var countryParam = new SqlParameter("@Country", SqlDbType.NVarChar)
                {
                    Value = address.Country
                };
                var postalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar)
                {
                    Value = address.PostalCode
                };
                var stateParam = new SqlParameter("@State", SqlDbType.NVarChar)
                {
                    Value = address.State
                };
                command.Parameters.Add(addressIdParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(countryParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                
                try
                {
                    var updatedAddress = command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    address = null;
                    Console.WriteLine(ex);
                }

            }
            return address;

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

        public List<Address> GetAll()
        {
            var addresses = new List<Address>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Addresses]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address
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
                        });
                    }
                    return addresses;
                }

            }

        }

        public List<Address> Read(int offset, int count)
        {
            var addresses = new List<Address>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Addresses] ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @Count ROWS ONLY", connection);
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
                        addresses.Add(new Address
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
                        });
                    }

                }

            }
            return addresses;
        }

        public List<Address> Read(int offset, int count, string customerId)
        {
            var addresses = new List<Address>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Addresses] WHERE CustomerID = @CustomerId ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @Count ROWS ONLY", connection);
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
                        addresses.Add(new Address
                        {
                            Id = (int)reader["Id"],
                            //CustomerId = (int)reader["CustomerId"],
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            Country = reader["Country"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString()
                        });
                    }

                }

            }
            return addresses;
        }

        public List<Address> GetAllById(string customerId)
        {
            var addresses = new List<Address>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Addresses] WHERE CustomerID = @CustomerId", connection);
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId,
                };
                command.Parameters.Add(customerIdParam);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Address
                        {
                            Id = (int)reader["Id"],
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            Country = reader["Country"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            State = reader["State"].ToString()
                        });
                    }

                }

            }
            return addresses;
        }

        public int Count()
        {
            int count;
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM [s1].[Addresses]", connection);
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
