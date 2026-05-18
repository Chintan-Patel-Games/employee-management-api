namespace EmployeeManagement.DAL.DTOs.Common;

public class PaginationFilterDto
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}