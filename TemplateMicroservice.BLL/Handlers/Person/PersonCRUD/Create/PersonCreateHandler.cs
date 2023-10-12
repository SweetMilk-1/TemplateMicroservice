using MediatR;
using TemplateMicroservice.BLL.Interfaces.Services.Person;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Create;

public class PersonCreateHandler : IRequestHandler<PersonCreateRequest, int>
{
    private readonly IPersonService _personService;

    public PersonCreateHandler (IPersonService personService)
    {
        _personService = personService;
    }

    public Task<int> Handle(PersonCreateRequest request, CancellationToken cancellationToken)
    {
        return _personService.Create(request.Person, cancellationToken);
    }
}
