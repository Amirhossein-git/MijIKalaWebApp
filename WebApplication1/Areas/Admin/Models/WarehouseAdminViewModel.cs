using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Areas.Admin.Models
{
    public class WarehouseAdminViewModel
    {
        public List<Warehouse> Warehouses { get; set; }

        public List<WarehouseItem> WarehouseItems { get; set; }

        public Warehouse AddedWarehouse { get; set; }

    }
}
