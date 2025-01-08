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
        public List<StorehouseHistoryTL> GetExpiringMaterials()
        {
            var exMaterial = new List<StorehouseHistoryTL>();
            string query = @"SELECT 
    WarehouseHistory.HistoryID, 
    Materials.MaterialID, 
    Materials.MaterialName,
    WarehouseHistory.Quantity AS EntryQuantity,
    Materials.Unit, 
    Suppliers.SupplierName, 
    Suppliers.SupplierPhone,
    Materials.ExpiryDate, 
    WarehouseHistory.EntryDate
FROM 
    WarehouseHistory
LEFT JOIN 
    Materials ON WarehouseHistory.MaterialID = Materials.MaterialID
LEFT JOIN 
    Suppliers ON WarehouseHistory.SupplierID = Suppliers.SupplierID
WHERE 
    Materials.ExpiryDate BETWEEN GETDATE() AND DATEADD(day, 7, GETDATE());
";

            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exMaterial.Add(new StorehouseHistoryTL
                        {
                            HistoryID = reader.GetInt32(reader.GetOrdinal("HistoryID")),
                            MaterialID = reader.GetInt32(reader.GetOrdinal("MaterialID")),
                            Tên_nguyên_liệu = reader.GetString(reader.GetOrdinal("MaterialName")),
                            Số_lượng = reader.GetInt32(reader.GetOrdinal("EntryQuantity")),
                            Đơn_vị = reader.GetString(reader.GetOrdinal("Unit")),

                            Tên_nhà_cung_cấp = reader.IsDBNull(reader.GetOrdinal("SupplierName")) ? null : reader.GetString(reader.GetOrdinal("SupplierName")),
                            SDT_nhà_cung_cấp = reader.IsDBNull(reader.GetOrdinal("SupplierPhone")) ? null : reader.GetString(reader.GetOrdinal("SupplierPhone")),
                            Ngày_nhập_kho = reader.GetDateTime(reader.GetOrdinal("EntryDate")),
                            Hạn_sử_dụng = reader.GetDateTime(reader.GetOrdinal("ExpiryDate")),
                        });
                    }
                }
            }

            return exMaterial;

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

        public MaterialStatistics GetMaterialStatistics()
        {
            var allMaterials = GetAllMaterials();
            var statistics = new MaterialStatistics();

            DateTime now = DateTime.Now;
            DateTime sevenDaysFromNow = now.AddDays(7);

            foreach (var material in allMaterials)
            {
                if (material.Hạn_sử_dụng < now)
                {
                    statistics.ExpiredMaterials++;
                }
                else if (material.Hạn_sử_dụng <= sevenDaysFromNow)
                {
                    statistics.ExpiringSoonMaterials++;
                }
                else
                {
                    statistics.ValidMaterials++;
                }
            }

            return statistics;
        }

        public class MaterialStatistics
        {
            public int ValidMaterials { get; set; }
            public int ExpiredMaterials { get; set; }
            public int ExpiringSoonMaterials { get; set; }
        }

    }
}

