using CoffeeManagement.DL;
using CoffeeManagement.TL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.Bl
{
    public class StorehouseBL
    {
        private readonly StorehouseDL storehouseDAL;
        public StorehouseBL()
        {
            storehouseDAL = new StorehouseDL();
        }
        public List<StorehouseHistoryTL> GetEntryHistory()
        {
            return storehouseDAL.GetHistory();
        }
    }
}
