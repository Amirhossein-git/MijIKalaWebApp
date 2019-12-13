using MijiKalaWebApp.Models.DataModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.ViewModels
{
    public class PersonViewModel:Person
    {
        public string Role { get; set; }
    }
}
