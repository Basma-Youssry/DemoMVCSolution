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
using Demo.BusinessLogic.Services.AttatchmentService;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{

    public class EmployeeService(IUnitOfWork _unitofwork, IMapper _mapper,IAttachmentService _attachmentService) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName)
        {


            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(EmployeeSearchName))
                employees = _unitofwork.EmployeeReprository.GetAll();
               
            
            else
                 employees =_unitofwork.EmployeeReprository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));

            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return employeesDto;



        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var employee = _unitofwork.EmployeeReprository.GetById(id);

            return  employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);    
        }

        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);

            if (employeeDto.Image is not null)
              employee.ImageName = _attachmentService.Upload(employeeDto.Image, "Images");

            _unitofwork.EmployeeReprository.Add(employee); //AddLocally

            return _unitofwork.SaveChanges();
        }

        public int UpdateEmployee(UpdatedEmployeeDto EmployeeDto)
        {
             _unitofwork.EmployeeReprository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(EmployeeDto));

            return _unitofwork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var Employee = _unitofwork.EmployeeReprository.GetById(id);

            if (Employee is null) return false;

            else
            {
                Employee.IsDeleted = true;
                _unitofwork.EmployeeReprository.Update(Employee);

                return _unitofwork.SaveChanges()  > 0 ? true : false;
            }



        }

      
    }
}
