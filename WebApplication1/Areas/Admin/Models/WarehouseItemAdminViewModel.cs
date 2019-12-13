using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Areas.Admin.Models
{
    public class WarehouseItemAdminViewModel
    {
        public string Function { get; set; }

        public Guid WarehouseItemId { get; set; }

        public int WarehouseId { get; set; }

        public Guid ProductId { get; set; }

        public int NumberInWarehouse { get; set; }
    }
}
