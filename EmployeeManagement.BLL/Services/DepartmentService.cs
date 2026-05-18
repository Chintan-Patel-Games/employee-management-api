using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.DAL.Contracts;
using EmployeeManagement.DAL.DTOs.Department;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository) =>
        _departmentRepository = departmentRepository;

    public async Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync( int pageNumber, int pageSize)
    {
        var departments = await _departmentRepository.GetAllAsync(pageNumber, pageSize);

        return departments.Select(d => new DepartmentResponseDto
        {
            Id = d.Id,
            Name = d.Name
        });
    }

    public async Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);

        if (department == null)
            return null;

        return new DepartmentResponseDto
        {
            Id = department.Id,
            Name = department.Name
        };
    }

    public async Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        var department = new Department
        {
            Name = dto.Name
        };

        var createdDepartment = await _departmentRepository.AddAsync(department);

        return new DepartmentResponseDto
        {
            Id = createdDepartment.Id,
            Name = createdDepartment.Name
        };
    }
}