using MediatR;
using TemplateMicroservice.BLL.Interfaces.Services.Person;
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Models;

namespace TemplateMicroservice.BLL.Handlers.Person.GetPeople
{
    internal class GetPeopleHandler : IRequestHandler<GetPeopleRequest, PaginationModel<PersonDto>>
    {
        private readonly IPersonService _personService;
        public GetPeopleHandler(IPersonService personService)
        {
            _personService = personService;
        }
        public Task<PaginationModel<PersonDto>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            return _personService.GetWithPagination(request.Page, request.PageCount, cancellationToken);
        }
    }
}
