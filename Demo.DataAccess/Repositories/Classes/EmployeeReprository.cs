using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Repositories.Classes
{
    internal class EmployeeReprository(ApplicationDbContext dbcontext):Generic_Reprository<Employee>(dbcontext), IEmployeeReprository
    {
      
    }
}
