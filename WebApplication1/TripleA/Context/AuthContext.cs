using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.TripleA.Context
{
    public class AuthContext :IdentityDbContext<IdentityUser>
    {
        public AuthContext(DbContextOptions options):base(options)
        {

        }
    }
}
