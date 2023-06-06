using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tinker.Persistence.Configurations;
using tinker.Persistence.Identity;

namespace tinker.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppIdentityDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-CMFM3SG;Database=tinkerIdentityDb;Trusted_Connection=True;TrustServerCertificate=True");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
