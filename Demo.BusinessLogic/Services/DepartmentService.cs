using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Repositories;

namespace Demo.BusinessLogic.Services
{
    internal class DepartmentService
    {
        public DepartmentService(IDepartmentReprository departmentReposatory)//1.Inject
        {
            
        }
    }
}
