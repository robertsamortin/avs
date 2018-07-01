using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avsserv.Models
{
    public class DBCon : IdentityDbContext<IdentityUser>
    {
        public DBCon(DbContextOptions<DBCon> options) : base(options)
        {

        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<SystemUsers> SystemUsers { get; set; }
    }
}
