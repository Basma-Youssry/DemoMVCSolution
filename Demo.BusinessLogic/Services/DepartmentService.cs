using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransfareObject;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Modules;
using Demo.DataAccess.Repositories;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentReprository _departmentReposatory) : IDepartmentService
    {
        //GetAllDepartments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentReposatory.GetAll();

            //Manual mapping
            //var departmentsToReturn = departments.Select(D => new DepartmentDto()
            //{
            //    DeptId = D.Id,
            //    Name = D.Name,
            //    Code = D.Code,
            //    Description = D.Description,
            //    DateOfCreation = DateOnly.FromDateTime(D.CreatedOn)
            //});
            //return departmentsToReturn;


            //MappingWithExtension methods

            return departments.Select(D => D.ToDepartmentDto());
        }

        //GetDepartmentById
        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _departmentReposatory.GetById(id);

            //Mapping ways
            //1-Manual mapping
            //2-Auto mapper (Recommended with bigger project)
            //3-Constructor mapping
            //4-Extension methods (Recommended with small project)

            //First way (Manual mapping)

            //if (department is null)
            //    return null;
            //else
            //{
            //    var departmentToReturn = new DepartmentDetailsDto()
            //    {
            //        Id = department.Id,
            //        Name = department.Name,
            //        Code = department.Code,
            //        Description = department.Description,
            //        CreatedBy = department.CreatedBy,
            //        CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
            //        IsDeleted = department.IsDeleted,
            //        LastModifiedBy = department.LastModifiedBy,
            //        LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn)
            //    };
            //    return departmentToReturn;
            //}

            //Second way (Manual mapping)
            //return department is null ? null : new DepartmentDetailsDto()
            //{
            //    Id = department.Id,
            //    Name = department.Name,
            //    Code = department.Code,
            //    Description = department.Description,
            //    CreatedBy = department.CreatedBy,
            //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
            //    IsDeleted = department.IsDeleted,
            //    LastModifiedBy = department.LastModifiedBy,
            //    LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn)
            //};
            //Constructor mapping
            //return department is null ? null : new DepartmentDetailsDto(department);



            //MappingWithExtension methods (Recommended with small project)
            return department is null ? null : department.ToDepartmenDetailsDto();








        }

        //AddDepartment
        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();

            return _departmentReposatory.Add(department);
        }

        //UpdateDepartment
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {

            return _departmentReposatory.Update(departmentDto.ToEntity());
        }

        public bool DeleteDepartment(int id)
        {
            var Department = _departmentReposatory.GetById(id);

            if (Department is null) return false;
            else
            {
                int Result = _departmentReposatory.Remove(Department);
                return Result > 0 ? true : false;
            }
        }
    }
}
