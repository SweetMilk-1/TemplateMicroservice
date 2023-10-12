using FluentValidation;
using TemplateMicroservice.BLL.Handlers.PersonCRUD.Update;

namespace TemplateMicroservice.BLL.Validators.Person
{
    internal class PersonUpdateRequestValidator : AbstractValidator<PersonUpdateRequest>
    {
        public PersonUpdateRequestValidator()
        {
            RuleFor(o => o).SetValidator(new PersonDtoValidator());
        }
    }
}
