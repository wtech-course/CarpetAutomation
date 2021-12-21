using CarpetAutomation.DataAccess.Configurations;
using CarpetAutomation.Entities;
using CarpetAutomation.Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarpetAutomation.DataAccess
{
  
    public class CarpetDBContext : IdentityDbContext<Users,AppRole,int>
    {
        public CarpetDBContext()
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        //public DbSet<Users> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        //{
        //    base.OnConfiguring(optionsbuilder);
        //    optionsbuilder.UseSqlServer("Server=DESKTOP-7N3D723;Database=WtechGeneral;uid=sa;pwd=123");

        //}
        public CarpetDBContext(DbContextOptions<CarpetDBContext> options)
           : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "user" });
            base.OnModelCreating(builder);
            builder
                .ApplyConfiguration(new BranchConfiguration());

            builder
                .ApplyConfiguration(new CompanyConfiguration());
        }


    }
}
