using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.DAL.DTOs.Employee;
using EmployeeManagement.Utility.Utility;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseApiController
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sortBy = null)
    {
        var employees = await _employeeService.GetAllEmployeesAsync(
                pageNumber,
                pageSize,
                sortBy);

        return SuccessResponse(
            employees,
            "Resources.EmployeesFetchedSucessful");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);

        if (employee == null)
            return ErrorResponse("Employee not found.");

        return SuccessResponse(
            employee,
            "Resources.EmployeeFetchedSucessful");
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchEmployees(
        [FromQuery] string name)
    {
        var employees = await _employeeService.SearchEmployeesByNameAsync(name);

        return SuccessResponse(
            employees,
            "Resources.EmployeesFetchedSucessful");
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
    {
        var createdEmployee = await _employeeService.CreateEmployeeAsync(dto);

        return CreatedResponse(
            nameof(GetEmployeeById),
            new { id = createdEmployee.Id },
            createdEmployee,
            "Resources.EmployeeCreatedSucessful");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto dto)
    {
        if (id != dto.Id)
            return ErrorResponse(Resources.EmployeeIDMismatch);

        var updatedEmployee = await _employeeService.UpdateEmployeeAsync(dto);

        if (updatedEmployee == null)
            return ErrorResponse(Resources.EmployeeNotFound);

        return SuccessResponse(
            updatedEmployee,
            "Resources.EmployeeUpdatedSucessful");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deleted = await _employeeService.DeleteEmployeeAsync(id);

        if (!deleted)
            return ErrorResponse(Resources.EmployeeNotFound);

        return NoContent();
    }
}