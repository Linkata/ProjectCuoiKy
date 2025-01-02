using CoffeeManagement.Model;
using CoffeeManagement.TL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.DL
{
    public class SupplierDL
    {
        public List<SupplierTL> GetSuppliers(string searchText = "")
        {
            var suppliers = new List<SupplierTL>();
            string query = @"SELECT Suppliers.SupplierID, Suppliers.SupplierName, Suppliers.SupplierPhone 
                             
                    FROM Suppliers";


            // Thêm điều kiện tìm kiếm nếu searchText không rỗng
            if (!string.IsNullOrEmpty(searchText))
            {
                query += " WHERE  Suppliers.SupplierName LIKE @searchText";
            }

            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            using (var command = new SqlCommand(query, connection))
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Gán giá trị cho tham số tìm kiếm
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                }

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        suppliers.Add(new SupplierTL
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("SupplierID")),
                            Tên_nhà_cung_cấp = reader.GetString(reader.GetOrdinal("SupplierName")),
                            SDT_nhà_cung_cấp = reader.GetString(reader.GetOrdinal("SupplierPhone")),

                        });
                    }
                }
            }

            return suppliers;
        }

        public void AddSupplier(SupplierTL suppliers)
        {
            var query = "INSERT INTO Materials ( SupplierID,SupplierName) " +
                        "VALUES (@SupplierID,@SupplierName)";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", suppliers.ID);
                    command.Parameters.AddWithValue("@SupplierName", suppliers.Tên_nhà_cung_cấp);
                    command.Parameters.AddWithValue("@SupplierPhone", suppliers.SDT_nhà_cung_cấp);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public int DeleteSupplier(int supplierID)
        {
            var query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", supplierID);
                    connection.Open(); return command.ExecuteNonQuery();
                }
            }
        }
        public int UpdSupplier(SupplierTL supplier)
        {
            var query = "UPDATE Suppliers SET SupplierName = @SupplierName, " +
                "SupplierPhone = @SupplierPhone ";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierName", supplier.Tên_nhà_cung_cấp);
                    command.Parameters.AddWithValue("@SupplierPhone", supplier.SDT_nhà_cung_cấp);

                    connection.Open(); return command.ExecuteNonQuery();
                }
            }
        }
    }
}
