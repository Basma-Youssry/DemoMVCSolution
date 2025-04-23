using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.Configurations;
using Demo.DataAccess.Modules.DepartmentModel;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Modules.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo.DataAccess.Data.DbContexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For Less Configurations
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());

            //For more Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
