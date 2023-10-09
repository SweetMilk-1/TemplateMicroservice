using FluentValidation;
using TemplateMicroservice.BLL.Models.Person;

namespace TemplateMicroservice.BLL.Validators.Person;

public class PersonDtoValidator: AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage("Name не может быть пустым!");
        RuleFor(r => r.Age).GreaterThanOrEqualTo(0).WithMessage("Age не может быть отрицательным!");
    }
}