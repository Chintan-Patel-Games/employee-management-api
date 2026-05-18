using EmployeeManagement.DAL.DTOs.Employee;

namespace EmployeeManagement.BLL.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync(int pageNumber, int pageSize, string? sortBy);

    Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id);

    Task<IEnumerable<EmployeeResponseDto>> SearchEmployeesByNameAsync(string name);

    Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto employee);

    Task<EmployeeResponseDto?> UpdateEmployeeAsync(UpdateEmployeeDto employee);

    Task<bool> DeleteEmployeeAsync(int id);
}