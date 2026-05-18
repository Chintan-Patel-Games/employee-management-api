using EmployeeManagement.DAL.Contracts;
using EmployeeManagement.DAL.Data;
using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAllAsync(
        int pageNumber,
        int pageSize)
    {
        return await _context.Departments
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _context.Departments
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Department> AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);

        await _context.SaveChangesAsync();

        return department;
    }
}