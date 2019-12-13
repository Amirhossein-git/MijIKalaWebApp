using Microsoft.EntityFrameworkCore;
using MijiKalaWebApp.Models.DataModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Contexts
{
    public class PersonsContext:DbContext
    {
        public PersonsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
