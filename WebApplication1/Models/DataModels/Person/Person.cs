using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.DataModels.Person
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
    }
}
