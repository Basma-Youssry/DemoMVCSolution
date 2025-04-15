using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransfareObject.DepartmentDto;
using Demo.BusinessLogic.DataTransfareObject.DepartmentDto.DepartmentDto;
using Demo.BusinessLogic.DataTransfareObject.DepartmentsDto;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Modules;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitofwork) : IDepartmentService
    {
        //GetAllDepartments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitofwork.DepartmenReprository.GetAll();

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
            var department = _unitofwork.DepartmenReprository.GetById(id);

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
        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();

             _unitofwork.DepartmenReprository.Add(department);

            return _unitofwork.SaveChanges();
        }

        //UpdateDepartment
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {

             _unitofwork.DepartmenReprository.Update(departmentDto.ToEntity());

            return _unitofwork.SaveChanges();
        }

        public bool DeleteDepartment(int id)
        {
            var Department = _unitofwork.DepartmenReprository.GetById(id);

            if (Department is null) return false;
            else
            {
                _unitofwork.DepartmenReprository.Remove(Department);
                return _unitofwork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
