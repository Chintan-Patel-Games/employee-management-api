using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.DAL.Contracts;
using EmployeeManagement.DAL.DTOs.Employee;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.BLL.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository) =>
        _employeeRepository = employeeRepository;

    public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployeesAsync(int pageNumber, int pageSize, string? sortBy)
    {
        var employees = await _employeeRepository.GetAllAsync(pageNumber, pageSize, sortBy);

        return employees.Select(e => new EmployeeResponseDto
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            Salary = e.Salary,
            DepartmentName = e.Department?.Name ?? string.Empty
        });
    }

    public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee == null)
            return null;

        return new EmployeeResponseDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Salary = employee.Salary,
            DepartmentName = employee.Department?.Name ?? string.Empty
        };
    }

    public async Task<IEnumerable<EmployeeResponseDto>> SearchEmployeesByNameAsync(string name)
    {
        var employees = await _employeeRepository.SearchByNameAsync(name);

        return employees.Select(e => new EmployeeResponseDto
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            Salary = e.Salary,
            DepartmentName = e.Department?.Name ?? string.Empty
        });
    }

    public async Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Email = dto.Email,
            Salary = dto.Salary,
            DepartmentId = dto.DepartmentId
        };

        var createdEmployee = await _employeeRepository.AddAsync(employee);

        return new EmployeeResponseDto
        {
            Id = createdEmployee.Id,
            Name = createdEmployee.Name,
            Email = createdEmployee.Email,
            Salary = createdEmployee.Salary,
            DepartmentName = createdEmployee.Department?.Name ?? string.Empty
        };
    }

    public async Task<EmployeeResponseDto?> UpdateEmployeeAsync(UpdateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            Salary = dto.Salary,
            DepartmentId = dto.DepartmentId
        };

        var updatedEmployee = await _employeeRepository.UpdateAsync(employee);

        if (updatedEmployee == null)
            return null;

        return new EmployeeResponseDto
        {
            Id = updatedEmployee.Id,
            Name = updatedEmployee.Name,
            Email = updatedEmployee.Email,
            Salary = updatedEmployee.Salary,
            DepartmentName = updatedEmployee.Department?.Name ?? string.Empty
        };
    }

    public async Task<bool> DeleteEmployeeAsync(int id) => await _employeeRepository.DeleteAsync(id);
}