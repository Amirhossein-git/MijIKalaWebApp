using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.DataModels
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }
        
        public string Telephone { get; set; }
        
        public string Manager { get; set; }

        public List<WarehouseItem> WarehouseItems { get; set; }

    }
}
