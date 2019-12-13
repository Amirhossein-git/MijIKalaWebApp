using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.DataModels
{
    public class WarehouseItem
    {
        public int Warehouseid { get; set; }

        public Guid WraehouseItemId { get; set; }

        public Product Product { get; set; }

        public int NumberInWarehouse { get; set; }
    }
}
