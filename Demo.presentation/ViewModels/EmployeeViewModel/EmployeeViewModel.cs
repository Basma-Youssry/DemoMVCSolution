
using System.ComponentModel.DataAnnotations;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Modules.Shared.Enums;

namespace Demo.presentation.ViewModels.EmployeeViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
       
        public int? Age { get; set; }
        
        public string? Address { get; set; }
       
        public decimal Salary { get; set; }
        
        public bool IsActive { get; set; }
        
        public string? Email { get; set; }
       
        public string? PhoneNumber { get; set; }
      
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
