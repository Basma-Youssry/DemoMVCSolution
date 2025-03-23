using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.Configurations;

namespace Demo.DataAccess.Data.DbContexts
{
    internal class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("ConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For Less Configurations
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());

            //For more Configurations
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
