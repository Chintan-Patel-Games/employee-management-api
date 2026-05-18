using EmployeeManagement.DAL.DTOs.Department;

namespace EmployeeManagement.BLL.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync(int pageNumber, int pageSize);

    Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id);

    Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentDto  department);
}