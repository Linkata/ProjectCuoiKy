using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.TL
{
    public class MaterialTL
    {
        public int ID { get; set; }
        public string Tên_nguyên_liệu { get; set; }
        public int Số_lượng { get; set; }

        public string Đơn_vị { get; set; }
        public DateTime Hạn_sử_dụng { get; set; }
        public string Tên_nhà_cung_cấp { get; set; }
        public string SDT_nhà_cung_cấp { get; set; }

        public int SupplierID { get; set; }
    }
}
