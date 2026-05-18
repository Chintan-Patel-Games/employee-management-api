using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.DAL.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync(
        int pageNumber,
        int pageSize,
        string? sortBy);

    Task<Employee?> GetByIdAsync(int id);

    Task<IEnumerable<Employee>> SearchByNameAsync(string name);

    Task<Employee> AddAsync(Employee employee);

    Task<Employee?> UpdateAsync(Employee employee);

    Task<bool> DeleteAsync(int id);
}