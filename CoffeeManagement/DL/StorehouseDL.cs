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
    public class StorehouseDL
    {
        public List<StorehouseHistoryTL> GetHistory()
        {
            var history = new List<StorehouseHistoryTL>();
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
                Suppliers ON WarehouseHistory.SupplierID = Suppliers.SupplierID";

            using (var connection = new SqlConnection(DatabaseHelper.GetConnectionString()))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        history.Add(new StorehouseHistoryTL
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

            return history;
        }
    }
}
