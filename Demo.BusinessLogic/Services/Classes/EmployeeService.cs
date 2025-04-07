using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransfareObject.DepartmentDto.DepartmentDto;
using Demo.BusinessLogic.DataTransfareObject.DepartmentsDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeeDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{

    public class EmployeeService(IEmployeeReprository _employeeReprository) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking)
        {
            var employees = _employeeReprository.GetAll();

            var employeesDto = employees.Select(E => new EmployeeDto()
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                IsActive = E.IsActive,
                Salary = E.Salary,
                Email = E.Email,
                Gender = E.Gender.ToString(),
                EmployeeType = E.EmployeeType.ToString()
            });

            return employeesDto;

        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = _employeeReprository.GetById(id);

            if (employee is null) return null;
            else return new EmployeeDetailsDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                CreatedBy = 1,
                CreatedOn = employee.CreatedOn,
                LastModifiedBy = 1,
                LastModifiedOn = employee.LastModifiedOn
            };
        }

        //public int CreateEmployee(CreatedEmployeeDto employeeDto)
        //{
        //    var employee = employeeDto.ToEntity();

        //    return _employeeReprository.Add(employee);
        //}

        //public int UpdateEmployee(UpdatedEmployeeDto EmployeeDto)
        //{
        //    return _employeeReprository.Update(EmployeeDto.ToEntity());
        //}

        //public bool DeleteEmployee(int id)
        //{
        //    var Employee = _employeeReprository.GetById(id);

        //    if (Employee is null) return false;

        //    else
        //    {
        //        int Result = _employeeReprository.Remove(Employee);

        //        return Result > 0 ? true : false;
        //    }



        //}

    }
}
