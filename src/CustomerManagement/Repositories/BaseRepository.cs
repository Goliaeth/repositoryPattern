using System.Data.SqlClient;

namespace CustomerManagement.Repositories
{
    public class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=localhost\\SQLEXPRESS;Database=CustomerLib_DB;Trusted_Connection=True;");
        }
    }
}
