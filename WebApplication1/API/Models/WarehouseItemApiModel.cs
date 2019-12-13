using MijiKalaWebApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.API.Models
{
    public class WarehouseItemApiModel
    {
        public Guid ProductId { get; set; }

        public int NumberInWarehouse { get; set; }
    }
}
