using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Areas.Admin.Models
{
    public class ContainInfoViewModel
    {
        public string Title { get; set; }

        public List<InfoItem> InfoItems { get; set; }
    }
}
