using FluentValidation;
using TemplateMicroservice.BLL.Handlers.Person.PersonCRUD.ReadAll;
using TemplateMicroservice.Core.Validators.Query;

namespace TemplateMicroservice.BLL.Validators.Person
{
    public class PersonReadAllRequestValidation: AbstractValidator<PersonReadAllRequest>
    {
        public PersonReadAllRequestValidation()
        {
            Include(new PaginationQueryValidator());
        }
    }
}
