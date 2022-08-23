﻿using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class NoteRepository : BaseRepository, IRepository<Note>
    {
        public Note Create(Note note)
        {
            Int32 newNoteId = 0;
            using var connection = GetConnection();
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
                newNoteId = (Int32)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            note.Id = (int)newNoteId;
            return note;
        }

        public Note Read(string noteId)
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand("SELECT * FROM [s1].[Notes] WHERE id = @noteId", connection);
            var noteIdParam = new SqlParameter("@noteId", SqlDbType.Int)
            {
                Value = noteId
            };
            command.Parameters.Add(noteIdParam);
            using var reader = command.ExecuteReader();
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

        public Note Update(Note note)
        {
            using var connection = GetConnection();
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

        public void Delete(string noteId)
        {
            using var connection = GetConnection();
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
}
