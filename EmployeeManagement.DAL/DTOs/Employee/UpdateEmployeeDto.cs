namespace EmployeeManagement.DAL.DTOs.Employee;

public class UpdateEmployeeDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
}