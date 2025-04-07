using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransfareObject.EmployeeDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;
using Demo.DataAccess.Modules.EmployeeModel;

namespace Demo.BusinessLogic.Factories
{
    internal static class EmployeeFactory
    {
        //public static EmployeeDto ToEmployeeDto(this Employee E)
        //{
        //    return new EmployeeDto
        //    {
        //        Id = E.Id,
        //        Name = E.Name,
        //        Age = E.Age,
        //        IsActive = E.IsActive,
        //        Salary = E.Salary,
        //        Email = E.Email,
        //        Gender = E.Gender,
        //        EmployeeType = E.EmployeeType
        //    };
        //}

        //public static EmployeeDetailsDto ToEmployeeDetailsDto(this Employee E)
        //{
        //    return new EmployeeDetailsDto
        //    {
        //        Id = E.Id,
        //        Name = E.Name,
        //        Age = E.Age,
        //        Address = E.Address,
        //        IsActive = E.IsActive,
        //        Salary = E.Salary,
        //        Email = E.Email,
        //        PhoneNumber = E.PhoneNumber,
        //        HiringDate = E.HiringDate,
        //        Gender = E.Gender,
        //        EmployeeType = E.EmployeeType
        //    };
        //}

        //public static Employee ToEntity(this CreatedEmployeeDto createdemployeedto)
        //{
        //    return new Employee()
        //    {
        //        Name = createdemployeedto.Name,
        //        Age = createdemployeedto.Age,
        //        Address = createdemployeedto.Address,
        //        IsActive = createdemployeedto.IsActive,
        //        Salary = createdemployeedto.Salary,
        //        Email = createdemployeedto.Email,
        //        PhoneNumber = createdemployeedto.PhoneNumber,
        //        HiringDate = createdemployeedto.HiringDate,
        //        Gender = createdemployeedto.Gender,
        //        EmployeeType = createdemployeedto.EmployeeType,
        //        CreatedBy = createdemployeedto.CreatedBy,
        //        LastModifiedBy = createdemployeedto.LastModifiedBy
        //    };
        //}

        //public static Employee ToEntity(this UpdatedEmployeeDto updatedEmployeeDto) => new Employee
        //{
        //    Name = updatedEmployeeDto.Name,
        //    Age = updatedEmployeeDto.Age,
        //    Address = updatedEmployeeDto.Address,
        //    IsActive = updatedEmployeeDto.IsActive,
        //    Salary = updatedEmployeeDto.Salary,
        //    Email = updatedEmployeeDto.Email,
        //    PhoneNumber = updatedEmployeeDto.PhoneNumber,
        //    HiringDate = updatedEmployeeDto.HiringDate,
        //    Gender = updatedEmployeeDto.Gender,
        //    EmployeeType = updatedEmployeeDto.EmployeeType,
        //    CreatedBy = updatedEmployeeDto.CreatedBy,
        //    LastModifiedBy = updatedEmployeeDto.LastModifiedBy
        //};

    }
}
