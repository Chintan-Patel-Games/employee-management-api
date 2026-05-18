using EmployeeManagement.DAL.Contracts;
using EmployeeManagement.DAL.Data;
using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync(
        int pageNumber,
        int pageSize,
        string? sortBy)
    {
        var query = _context.Employees
            .Include(e => e.Department)
            .AsQueryable();

        query = sortBy?.ToLower() switch
        {
            "name" => query.OrderBy(e => e.Name),

            "salary" => query.OrderBy(e => e.Salary),

            _ => query.OrderBy(e => e.Id)
        };

        return await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Employee>> SearchByNameAsync(string name)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Where(e => e.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        var existingEmployee = await _context.Employees.FindAsync(employee.Id);

        if (existingEmployee == null)
        {
            return null;
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Email = employee.Email;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.DepartmentId = employee.DepartmentId;

        await _context.SaveChangesAsync();

        return existingEmployee;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }
}