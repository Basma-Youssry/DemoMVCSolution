using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransfareObject;
using Demo.DataAccess.Modules;

namespace Demo.BusinessLogic.Factories
{
    internal static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D)
        {
           return new DepartmentDto()
            {

                DeptId = D.Id,
                Name = D.Name,
                Code = D.Code,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
            };
        }


        public static DepartmentDetailsDto ToDepartmenDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                IsDeleted = department.IsDeleted,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn)
            };
        }


        public static Department ToEntity(this CreatedDepartmentDto createdDepartmentDto)
        {
            return new Department()
            {
                Name = createdDepartmentDto.Name,
                Code = createdDepartmentDto.Code,
                Description = createdDepartmentDto.Description,
                CreatedOn = createdDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto updateDepartmentDto) => new Department()

        {
            Id = updateDepartmentDto.Id,
            Name = updateDepartmentDto.Name,
            Code = updateDepartmentDto.Code,
            CreatedOn = updateDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
            Description = updateDepartmentDto.Description
        };
            
       
    }
}
