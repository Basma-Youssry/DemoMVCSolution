using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Modules.Shared.Enums;

namespace Demo.BusinessLogic.DataTransfareObject.EmployeeDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }   
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

    }
}
