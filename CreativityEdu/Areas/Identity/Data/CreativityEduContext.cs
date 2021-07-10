using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativityEdu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreativityEdu.Data
{
    public class CreativityEduContext : IdentityDbContext<AppUser>
    {
        public CreativityEduContext(DbContextOptions<CreativityEduContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employess> Employess { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
