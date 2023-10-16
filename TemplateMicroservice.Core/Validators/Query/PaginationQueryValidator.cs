using FluentValidation;
using TemplateMicroservice.Core.Interfaces.Query;

namespace TemplateMicroservice.Core.Validators.Query;

public class PaginationQueryValidator:AbstractValidator<IPaginationQuery>
{
    public PaginationQueryValidator()
    {
        RuleFor(x => x.Page).NotNull().GreaterThanOrEqualTo(1).WithMessage("Page должет быть больше 0");
        RuleFor(x => x.PageCount).NotNull().GreaterThanOrEqualTo(1).WithMessage("PageCount должет быть больше 0");
    }
}
