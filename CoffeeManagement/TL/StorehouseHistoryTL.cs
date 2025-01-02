using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.TL
{
    public class StorehouseHistoryTL
    {
        public int HistoryID { get; set; }
        public int MaterialID { get; set; }
        public string Tên_nguyên_liệu { get; set; }
        public int Số_lượng { get; set; }
        public string Đơn_vị { get; set; }
        public string Tên_nhà_cung_cấp { get; set; }
        public string SDT_nhà_cung_cấp { get; set; }
        public DateTime Ngày_nhập_kho { get; set; }
        public DateTime Hạn_sử_dụng { get; set; }
    }
}
