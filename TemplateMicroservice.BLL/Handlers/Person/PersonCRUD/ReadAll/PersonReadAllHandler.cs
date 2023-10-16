using MediatR;
using TemplateMicroservice.BLL.Interfaces.Services.Person;
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Interfaces.Query;
using TemplateMicroservice.Core.Models;

namespace TemplateMicroservice.BLL.Handlers.Person.PersonCRUD.ReadAll
{
    internal class PersonReadAllHandler : IRequestHandler<PersonReadAllRequest, PaginationModel<PersonDto>>
    {
        private readonly IPersonService _personService;
        public PersonReadAllHandler(IPersonService personService)
        {
            _personService = personService;
        }
        public Task<PaginationModel<PersonDto>> Handle(PersonReadAllRequest request, CancellationToken cancellationToken)
        {
            return _personService.GetWithPagination(request, cancellationToken);
        }
    }
}
