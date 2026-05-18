using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.DAL.DTOs.Department;
using EmployeeManagement.Utility.Utility;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : BaseApiController
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService) =>
        _departmentService = departmentService;

    [HttpGet]
    public async Task<IActionResult> GetAllDepartments(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var departments = await _departmentService.GetAllDepartmentsAsync(
                pageNumber,
                pageSize);

        return SuccessResponse(
            departments,
            "Resources.DepartmentsFetchedSucessful");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);

        if (department == null)
            return ErrorResponse("Department not found.");

        return SuccessResponse(
            department,
            "Resources.DepartmentFetchedSucessful");
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentDto dto)
    {
        var createdDepartment = await _departmentService.CreateDepartmentAsync(dto);

        return CreatedResponse(
            nameof(GetDepartmentById),
            new { id = createdDepartment.Id },
            createdDepartment,
            "Resources.DepartmentCreatedSucessful");
    }
}