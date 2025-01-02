using System.Data;
using System.Data.SqlClient;

namespace CoffeeManagement.DAL
{
    public class UserDAL
    {
        public bool CheckUserCredentials(string username, string password)
        {
            string qry = "SELECT COUNT(*) FROM users WHERE username = @user AND upass = @pass";
            using (SqlConnection con = new SqlConnection(MainClass.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
