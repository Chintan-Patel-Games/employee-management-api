using EmployeeManagement.BLL.Utilities;
using EmployeeManagement.DAL.DTOs.Employee;
using FluentValidation;

namespace EmployeeManagement.BLL.Validators.Employee;

public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(Resources.NameRequired)
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(Resources.EmailRequired)
            .EmailAddress()
            .WithMessage(Resources.InvalidEmailFormat);

        RuleFor(x => x.Salary)
            .GreaterThan(0)
            .WithMessage(Resources.SalaryGreaterThanZero);

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage(Resources.DepartmentRequired);
    }
}