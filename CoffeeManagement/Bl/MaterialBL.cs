using CoffeeManagement.DL;
using CoffeeManagement.Model;
using CoffeeManagement.TL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.Bl
{
    public class MaterialBL
    {
        private readonly MaterialDL materialDAL;

        public MaterialBL()
        {
            materialDAL = new MaterialDL();
        }

        // Lấy tất cả nguyên vật liệu (MaterialTL)
        public List<MaterialTL> GetAllMaterials()
        {
            return materialDAL.GetMaterials();
        }

        public List<SupplierTL> GetSuppliers()
        {
            var suppliers = new List<SupplierTL>();
            string query = @"SELECT SupplierID, SupplierName, SupplierPhone FROM Suppliers";
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            using (var command = new SqlCommand(query, connection))
            {
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

        // Lấy danh sách nguyên vật liệu sắp hết hạn (MaterialTL)
        public List<MaterialTL> GetExpiringMaterials()
        {
            var allMaterials = materialDAL.GetMaterials();
            return allMaterials.Where(m => (m.Hạn_sử_dụng - DateTime.Now).TotalDays <= 3).ToList();
        }

        // Thêm nguyên vật liệu mới (MaterialTL)
        public void AddMaterial(MaterialTL material)
        {
            if (material.Số_lượng < 0)
                throw new Exception("Quantity cannot be negative.");
            materialDAL.AddMaterial(material);
        }
        public int UpdMaterial(MaterialTL material)
        {
            try
            {
                return new MaterialDL().UpdMaterial(material);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int DeleteMaterial(int materialID)
        {
            try
            {
                return new MaterialDL().DeleteMaterial(materialID);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int GetOrCreateSupplierID(string supplierName, string supplierPhone)
        {
            int supplierID = -1;

            // Tạo kết nối và truy vấn để kiểm tra xem nhà cung cấp đã tồn tại chưa
            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                connection.Open();

                // Truy vấn để kiểm tra nhà cung cấp
                string checkQuery = @"SELECT SupplierID FROM Suppliers WHERE SupplierName = @SupplierName AND SupplierPhone = @SupplierPhone";
                using (var checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@SupplierName", supplierName);
                    checkCommand.Parameters.AddWithValue("@SupplierPhone", supplierPhone);

                    var result = checkCommand.ExecuteScalar();
                    if (result != null)
                    {
                        supplierID = Convert.ToInt32(result);
                    }
                }

                // Nếu nhà cung cấp chưa tồn tại, thêm mới nhà cung cấp và lấy SupplierID
                if (supplierID == -1)
                {
                    string insertQuery = @"INSERT INTO Suppliers (SupplierName, SupplierPhone) OUTPUT INSERTED.SupplierID VALUES (@SupplierName, @SupplierPhone)";
                    using (var insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@SupplierName", supplierName);
                        insertCommand.Parameters.AddWithValue("@SupplierPhone", supplierPhone);

                        supplierID = (int)insertCommand.ExecuteScalar();
                    }
                }
            }

            return supplierID;
        }
    }
}
