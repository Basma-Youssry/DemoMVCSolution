using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

    public class EmployeeService(IEmployeeReprository _employeeReprository, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking = false)
        {
            var employees = _employeeReprository.GetAll(WithTracking);

            //Src = Employee
            //Dest = EployeeDto

            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeesDto;


        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = _employeeReprository.GetById(id);

            return  employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee); 


            
        }

        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);

            return _employeeReprository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto EmployeeDto)
        {
            return _employeeReprository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(EmployeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            var Employee = _employeeReprository.GetById(id);

            if (Employee is null) return false;

            else
            {
                Employee.IsDeleted = true;
                int Result = _employeeReprository.Update(Employee);

                return Result > 0 ? true : false;
            }



        }

    }
}
