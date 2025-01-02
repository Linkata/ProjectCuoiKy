using CoffeeManagement.Model;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeManagement.BL
{
    public static class UserService
    {
        public static string CurrentUser { get; private set; }

        // Kiểm tra thông tin người dùng
        public static bool IsValidUser(string username, string password)
        {
            string qry = @"SELECT * FROM users WHERE username = @username AND upass = @password";
            string conString = DatabaseHelper.GetConnectionString();
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    CurrentUser = dt.Rows[0]["uName"].ToString();
                    return true;
                }
                return false;
            }
        }
    }
}
