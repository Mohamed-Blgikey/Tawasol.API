using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tawasol.DAL.Extend;

namespace Tawasol.DAL.Database
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>(e =>
            {
                e.Property(x => x.FullName)
                .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

                e.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            });

            

            base.OnModelCreating(builder);
        }


    }
}
