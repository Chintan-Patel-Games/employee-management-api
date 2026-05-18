namespace EmployeeManagement.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}