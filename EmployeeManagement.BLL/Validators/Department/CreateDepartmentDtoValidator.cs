using EmployeeManagement.BLL.Utilities;
using EmployeeManagement.DAL.DTOs.Department;
using FluentValidation;

namespace EmployeeManagement.BLL.Validators.Department;

public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
{
    public CreateDepartmentDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(Resources.DepartmentNameRequired)
            .MinimumLength(2)
            .MaximumLength(50);
    }
}