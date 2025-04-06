using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.DbContexts;
using Demo.DataAccess.Modules.DepartmentModel;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class DepartmentReprository(ApplicationDbContext dbContext) : Generic_Reprository<Department>(dbContext), IDepartmentReprository
    {
       

    }
}
