using FluentValidation;
using TemplateMicroservice.BLL.Handlers.PersonCRUD.Create;

namespace TemplateMicroservice.BLL.Validators.Person
{
    public class PersonCreateRequestValidator:AbstractValidator<PersonCreateRequest>
    {
        public PersonCreateRequestValidator()
        {
            RuleFor(o => o.Person).SetValidator(new PersonDtoValidator());
        }
    }
}
