using Demo.BusinessLogic.DataTransfareObject.EmployeeDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool WithTracking);

        EmployeeDetailsDto GetEmployeeById(int id);
        //int CreateEmployee(CreatedEmployeeDto employeeDto);

        //int UpdateEmployee(UpdatedEmployeeDto EmployeeDto);
        //bool DeleteEmployee(int id);

    }
}