using Demo.BusinessLogic.DataTransfareObject.EmployeeDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;

namespace Demo.BusinessLogic.Services
{
    public interface IEmployeeService
    {
        int CreateEmployee(CreatedEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDetailsDto GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDto EmployeeDto);
    }
}