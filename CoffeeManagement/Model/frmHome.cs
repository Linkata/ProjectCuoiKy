using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();


        }

        private void btnShowRevenue_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            string connectionString = "Data Source=LAPTOP-EF65QNAB\\SQLEXPRESS;Initial Catalog=CM;Persist Security Info=True;User ID=sa;Password=sa;"; // Thay thế bằng chuỗi kết nối thực tế của bạn
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT aDate, SUM(amount) AS [Tổng doanh thu]
                         FROM tblMain m
                         JOIN tblDetails d ON m.MainID = d.MainID
                         WHERE aDate BETWEEN @startDate AND @endDate
                         GROUP BY aDate
                         ORDER BY aDate";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();

                    DisplayGunaChart(dt);
                }
            }
        }

        private void DisplayGunaChart(DataTable dt)
        {
            // Xóa các series cũ trong biểu đồ
            guna2ChartRevenue.Datasets.Clear();

            // Tạo một series mới cho biểu đồ cột
            var columnSeries = new Guna.Charts.WinForms.GunaBarDataset
            {
                Label = "Doanh thu hàng ngày"
            };

            // Tạo danh sách các ngày giữa ngày bắt đầu và ngày kết thúc
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            var dateList = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dateList.Add(date);
            }

            // Tạo từ điển để lưu trữ doanh thu theo ngày
            var revenueDict = new Dictionary<DateTime, decimal>();
            foreach (DataRow row in dt.Rows)
            {
                DateTime saleDate = Convert.ToDateTime(row["aDate"]);
                decimal totalRevenue = Convert.ToDecimal(row["Tổng doanh thu"]);
                revenueDict[saleDate] = totalRevenue;
                Console.WriteLine($"{row["aDate"]}: {row["Tổng doanh thu"]}");
            }

            // Thêm dữ liệu từ từ điển vào series
            foreach (var kvp in revenueDict)
            {
                DateTime date = kvp.Key;
                decimal totalRevenue = kvp.Value;
                string formattedDate = date.ToString("dd/MM/yyyy");
                columnSeries.DataPoints.Add(formattedDate, (double)totalRevenue);

            }

            // Thêm series vào biểu đồ
            guna2ChartRevenue.Datasets.Add(columnSeries);

            // Cập nhật biểu đồ để hiển thị dữ liệu mới
            guna2ChartRevenue.Update();
        }

        private void btnShowProductSales_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-EF65QNAB\\SQLEXPRESS;Initial Catalog=CM;Persist Security Info=True;User ID=sa;Password=sa;"; // Thay thế bằng chuỗi kết nối thực tế của bạn
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT pName, SUM(qty) AS [Tổng doanh số]
                         FROM tblDetails d
                         JOIN products p ON p.pID = d.proID
                         GROUP BY pName
                         ORDER BY pName";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();

                    DisplayPieChart(dt);
                }
            }
        }
        private void DisplayPieChart(DataTable dt)
        {
            // Xóa các series cũ trong biểu đồ
            guna2ChartSale.Datasets.Clear();
            // ẩn trục x,y,đặt vị trí chú giải sang phải
            guna2ChartSale.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            guna2ChartSale.XAxes.Display = false;
            guna2ChartSale.YAxes.Display = false;

            // Tạo một series mới cho biểu đồ tròn
            var pieSeries = new Guna.Charts.WinForms.GunaPieDataset()
            {
                Label = "Doanh số"
            };



            // Thêm dữ liệu từ DataTable vào series
            foreach (DataRow row in dt.Rows)
            {

                string productName = row["pName"].ToString();
                decimal totalSales = Convert.ToDecimal(row["Tổng doanh số"]);

                // Thêm điểm dữ liệu vào series (tên sản phẩm và doanh số)
                pieSeries.DataPoints.Add(productName, (double)totalSales);
            }

            // Thêm series vào biểu đồ
            guna2ChartSale.Datasets.Add(pieSeries);

            // Cập nhật biểu đồ để hiển thị dữ liệu mới
            guna2ChartSale.Update();
        }


    }
}