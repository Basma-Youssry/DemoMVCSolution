using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Modules;

namespace Demo.BusinessLogic.DataTransfareObject.DepartmentDto.DepartmentDto
{
    public class DepartmentDetailsDto
    {
        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    Code = department.Code;
        //    Description = department.Description;
        //    CreatedBy = department.CreatedBy;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn);
        //    IsDeleted = department.IsDeleted;
        //    LastModifiedBy = department.LastModifiedBy;
        //    LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn);
        //}
        public int Id { get; set; }

        public int CreatedBy { get; set; } //User Id

        public DateOnly CreatedOn { get; set; }

        public int LastModifiedBy { get; set; } //User Id

        public DateOnly LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; } //SoftDelete


        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }


    }
}
