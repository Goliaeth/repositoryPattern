using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class NoteRepository : BaseRepository, IDepRepository<Note>
    {
        public Note Create(Note note)
        {
            int newNoteId = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO [s1].[Notes] (CustomerId, NoteText) VALUES (@CustomerId, @NoteText)", connection);
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = note.CustomerId
                };
                var noteTextParam = new SqlParameter("@NoteText", SqlDbType.NVarChar, 200)
                {
                    Value = note.NoteText
                };
                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteTextParam);
                try
                {
                    newNoteId = (int)(int?)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                note.Id = (int)newNoteId;
                return note;
            }
                
        }

        public Note Read(string noteId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Notes] WHERE id = @noteId", connection);
                var noteIdParam = new SqlParameter("@noteId", SqlDbType.Int)
                {
                    Value = noteId
                };
                command.Parameters.Add(noteIdParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Note
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            NoteText = reader["NoteText"].ToString()
                        };
                    }
                    return null;
                }
                    
            }
                
        }

        public Note Update(Note note)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [s1].[Notes] SET NoteText = @noteText WHERE id = @noteId", connection);
                var noteIdParam = new SqlParameter("@noteId", SqlDbType.Int)
                {
                    Value = note.Id
                };
                var noteNumberParam = new SqlParameter("@noteText", SqlDbType.NVarChar)
                {
                    Value = note.NoteText
                };
                command.Parameters.Add(noteIdParam);
                command.Parameters.Add(noteNumberParam);
                command.ExecuteNonQuery();

                return note;
            }
                
        }

        public void Delete(string noteId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM [s1].[Notes] WHERE id = @noteId", connection);
                var noteIdParam = new SqlParameter("@noteId", SqlDbType.Int)
                {
                    Value = noteId
                };
                command.Parameters.Add(noteIdParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Note> GetAll()
        {
            var notes = new List<Note>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Notes]", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new Note
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            NoteText = reader["NoteText"].ToString()
                        });
                    }
                    
                }

            }
            return notes;

        }

        public List<Note> Read(int offset, int count)
        {
            var notes = new List<Note>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Notes] ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @Count ROWS ONLY", connection);
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
                        notes.Add(new Note
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            NoteText = reader["NoteText"].ToString(),
                        });
                    }

                }

            }
            return notes;
        }

        public List<Note> Read(int offset, int count, string customerId)
        {
            var notes = new List<Note>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Notes] WHERE CustomerID = @CustomerId ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @Count ROWS ONLY", connection);
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
                        notes.Add(new Note
                        {
                            Id = (int)reader["Id"],
                            //CustomerId = (int)reader["CustomerId"],
                            NoteText = reader["NoteText"].ToString(),
                        });
                    }

                }

            }
            return notes;
        }

        public List<Note> GetAllById(string customerId)
        {
            var notes = new List<Note>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [s1].[Notes] WHERE CustomerID = @CustomerId", connection);
                var customerIdParam = new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId,
                };
                command.Parameters.Add(customerIdParam);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new Note
                        {
                            Id = (int)reader["Id"],
                            NoteText = reader["NoteText"].ToString(),
                        });
                    }
                }

            }
            return notes;
        }

        public int Count()
        {
            int count;
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM [s1].[Notes]", connection);
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
