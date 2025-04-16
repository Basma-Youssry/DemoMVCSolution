using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BusinessLogic.DataTransfareObject.EmployeeDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;
using Demo.DataAccess.Modules.EmployeeModel;
using Microsoft.Data.SqlClient;

namespace Demo.BusinessLogic.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.EmpGender, Options => Options.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.EmpType, Options => Options.MapFrom(src => src.EmployeeType))
                    .ForMember(dest => dest.Department, Options => Options.MapFrom(src =>  src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDto>()
                    .ForMember(dest => dest.Gender, Options => Options.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.EmployeeType, Options => Options.MapFrom(src => src.EmployeeType))
                    .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                    .ForMember(dest => dest.Department, Options => Options.MapFrom(src => src.Department != null ? src.Department.Name : null));


            CreateMap<CreatedEmployeeDto, Employee>()
                    .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)))
                    .ForMember(dest => dest.ImageName, options => options.MapFrom(src => src.Image));


            CreateMap<UpdatedEmployeeDto, Employee>()
                    .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
