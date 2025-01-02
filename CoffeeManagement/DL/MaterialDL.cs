using CoffeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeManagement.TL;
namespace CoffeeManagement.DL
{
    public class MaterialDL
    {
        public List<MaterialTL> GetMaterials(string searchText = "")
        {
            var materials = new List<MaterialTL>();
            string query = @"SELECT Materials.MaterialID, Materials.MaterialName, Materials.Quantity, 
                             Materials.Unit, Materials.ExpiryDate, Suppliers.SupplierName, Suppliers.SupplierPhone, 
                             Materials.SupplierID 
                      FROM Materials 
                      LEFT JOIN Suppliers ON Materials.SupplierID = Suppliers.SupplierID";

            // Thêm điều kiện tìm kiếm nếu searchText không rỗng
            if (!string.IsNullOrEmpty(searchText))
            {
                query += " WHERE Materials.MaterialName LIKE @searchText";
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
                        materials.Add(new MaterialTL
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("MaterialID")),
                            Tên_nguyên_liệu = reader.GetString(reader.GetOrdinal("MaterialName")),
                            Số_lượng = reader.GetInt32(reader.GetOrdinal("Quantity")),
                            Đơn_vị = reader.GetString(reader.GetOrdinal("Unit")),
                            Hạn_sử_dụng = reader.GetDateTime(reader.GetOrdinal("ExpiryDate")),
                            Tên_nhà_cung_cấp = reader.IsDBNull(reader.GetOrdinal("SupplierName")) ? null : reader.GetString(reader.GetOrdinal("SupplierName")),
                            SDT_nhà_cung_cấp = reader.IsDBNull(reader.GetOrdinal("SupplierPhone")) ? null : reader.GetString(reader.GetOrdinal("SupplierPhone")),
                        });
                    }
                }
            }

            return materials;
        }


        public void AddMaterial(MaterialTL material)
        {
            var query = "INSERT INTO Materials (MaterialName, Quantity, Unit, ExpiryDate, SupplierID) " +
                        "VALUES (@MaterialName, @Quantity, @Unit, @ExpiryDate, @SupplierID)";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaterialName", material.Tên_nguyên_liệu);
                    command.Parameters.AddWithValue("@Quantity", material.Số_lượng);
                    command.Parameters.AddWithValue("@Unit", material.Đơn_vị);
                    command.Parameters.AddWithValue("@ExpiryDate", material.Hạn_sử_dụng);
                    command.Parameters.AddWithValue("@SupplierName", material.Tên_nhà_cung_cấp);
                    command.Parameters.AddWithValue("@SupplierPhone", material.SDT_nhà_cung_cấp);
                    command.Parameters.AddWithValue("@SupplierID", material.SupplierID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            // Lấy lại MaterialID vừa thêm
            int materialID = GetMaterialID(material.Tên_nguyên_liệu, material.SupplierID);

            // Thêm lịch sử nhập kho
            AddWarehouseHistory(materialID, material);
        }

        private int GetMaterialID(string materialName, int supplierID)
        {
            var query = "SELECT MaterialID FROM Materials WHERE MaterialName = @MaterialName AND SupplierID = @SupplierID";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaterialName", materialName);
                    command.Parameters.AddWithValue("@SupplierID", supplierID);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void AddWarehouseHistory(int materialID, MaterialTL material)
        {
            var query = "INSERT INTO WarehouseHistory (MaterialID, SupplierID, Quantity, EntryDate) " +
                        "VALUES (@MaterialID, @SupplierID, @Quantity, @EntryDate)";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaterialID", materialID);
                    command.Parameters.AddWithValue("@SupplierID", material.SupplierID);
                    command.Parameters.AddWithValue("@Quantity", material.Số_lượng);
                    command.Parameters.AddWithValue("@EntryDate", DateTime.Now);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteMaterial(int materialID)
        {
            var query = "DELETE FROM Materials WHERE MaterialID = @MaterialID";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaterialID", materialID);
                    connection.Open(); return command.ExecuteNonQuery();
                }
            }
        }
        public int UpdMaterial(MaterialTL material)
        {
            var query = "UPDATE Materials SET MaterialName = @MaterialName, " +
                "Quantity = @Quantity, Unit = @Unit, " +
                "ExpiryDate = @ExpiryDate, SupplierID = @SupplierID " + "WHERE MaterialID = @MaterialID";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaterialID", material.ID);
                    command.Parameters.AddWithValue("@MaterialName", material.Tên_nguyên_liệu);
                    command.Parameters.AddWithValue("@Quantity", material.Số_lượng);
                    command.Parameters.AddWithValue("@Unit", material.Đơn_vị);
                    command.Parameters.AddWithValue("@ExpiryDate", material.Hạn_sử_dụng);
                    command.Parameters.AddWithValue("@SupplierID", material.SupplierID);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
