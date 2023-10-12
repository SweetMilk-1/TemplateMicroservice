using FluentValidation;
using TemplateMicroservice.BLL.Handlers.Person.GetPeople;

namespace TemplateMicroservice.BLL.Validators.Person
{
    public class GetPeopleRequestValidation: AbstractValidator<GetPeopleRequest>
    {
        public GetPeopleRequestValidation()
        {
            RuleFor(x=>x.Page).NotNull().GreaterThanOrEqualTo(1).WithMessage("Page должет быть больше 0");
            RuleFor(x=>x.PageCount).NotNull().GreaterThanOrEqualTo(1).WithMessage("PageCount должет быть больше 0");
        }
    }
}
