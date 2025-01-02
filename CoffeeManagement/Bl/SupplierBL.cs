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
    public class SupplierBL
    {
        private readonly SupplierDL supplierDAL;

        public SupplierBL()
        {
            supplierDAL = new SupplierDL();
        }

        // Lấy tất cả nguyên vật liệu (MaterialTL)
        public List<SupplierTL> GetAllSuppliers()
        {
            return supplierDAL.GetSuppliers();
        }




        // Thêm nguyên vật liệu mới (MaterialTL)
        public void AddSupplier(SupplierTL supplier)
        {
            if (supplier.Tên_nhà_cung_cấp is null)
                throw new Exception("Supplier name cannot be empty.");
            supplierDAL.AddSupplier(supplier);
        }
        public int UpdSupplier(SupplierTL supplier)
        {
            try
            {
                return new SupplierDL().UpdSupplier(supplier);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int DeleteSupplier(int supplierID)
        {
            try
            {
                return new SupplierDL().DeleteSupplier(supplierID);
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
