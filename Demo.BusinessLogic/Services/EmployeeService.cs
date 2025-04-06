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
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services
{
    public class EmployeeService(IEmployeeReprository _employeeReprository) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeReprository.GetAll();

            return employees.Select(E => E.ToEmployeeDto());
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = _employeeReprository.GetById(id);

            return employee is null ? null : employee.ToEmployeeDetailsDto();
        }

        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = employeeDto.ToEntity();

            return _employeeReprository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto EmployeeDto)
        {
            return _employeeReprository.Update(EmployeeDto.ToEntity());
        }

        public bool DeleteEmployee(int id)
        {
            var Employee = _employeeReprository.GetById(id);

            if (Employee is null) return false;

            else
            {
                int Result = _employeeReprository.Remove(Employee);

                return Result > 0 ? true : false;
            }



        }

    }
}
