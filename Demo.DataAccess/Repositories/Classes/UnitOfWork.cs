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
        private IEmployeeReprository _employeeReprository;
        private IDepartmentReprository _departmentReprository;
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(IEmployeeReprository employeeReprository,
                            IDepartmentReprository departmentReprository,
                            ApplicationDbContext _dbContext)
        {
            _employeeReprository = employeeReprository;
            _departmentReprository = departmentReprository;
            this._dbContext = _dbContext;
        }

        public IEmployeeReprository EmployeeReprository => _employeeReprository;

        public IDepartmentReprository DepartmenReprository => _departmentReprository;

        public int SaveChanges() =>  _dbContext.SaveChanges();
        
    }
}
