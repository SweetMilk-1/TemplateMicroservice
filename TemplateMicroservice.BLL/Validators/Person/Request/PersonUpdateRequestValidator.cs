using FluentValidation;
using TemplateMicroservice.BLL.Handlers.PersonCRUD.Update;
using TemplateMicroservice.BLL.Models.Person;

namespace TemplateMicroservice.BLL.Validators.Person
{
    public class PersonUpdateRequestValidator : PersonDtoValidator<PersonUpdateRequest>
    {
        public PersonUpdateRequestValidator()
        {
            RuleFor(o => o.Id).NotNull();
        }
    }
}
