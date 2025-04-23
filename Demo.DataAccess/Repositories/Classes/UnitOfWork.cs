using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IEmployeeReprository> _employeeReprository;
        private readonly Lazy<IDepartmentReprository> _departmentReprository;
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            _employeeReprository = new Lazy<IEmployeeReprository>(() => new EmployeeReprository(dbContext));
            _departmentReprository = new Lazy<IDepartmentReprository>(() => new DepartmentReprository(dbContext));
        }

        public Interfaces.IEmployeeReprository EmployeeReprository => _employeeReprository.Value;

        public IDepartmentReprository DepartmenReprository => _departmentReprository.Value;

        public int SaveChanges() =>  _dbContext.SaveChanges();
        
    }
}
