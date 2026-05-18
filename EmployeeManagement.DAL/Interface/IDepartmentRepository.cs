using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.DAL.Contracts;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllAsync(
        int pageNumber,
        int pageSize);

    Task<Department?> GetByIdAsync(int id);

    Task<Department> AddAsync(Department department);
}