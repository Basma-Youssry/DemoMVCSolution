using Demo.BusinessLogic.DataTransfareObject;

namespace Demo.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}