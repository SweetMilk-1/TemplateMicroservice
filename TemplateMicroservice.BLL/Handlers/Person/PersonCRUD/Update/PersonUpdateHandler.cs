using MediatR;
using TemplateMicroservice.BLL.Interfaces.Services.Person;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Update
{
    public class PersonUpdateHandler : IRequestHandler<PersonUpdateRequest, int>
    {
        readonly IPersonService _personService;

        public PersonUpdateHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public Task<int> Handle(PersonUpdateRequest request, CancellationToken cancellationToken) =>
            _personService.Update(request, cancellationToken);
    }
}
