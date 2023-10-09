using MediatR;
using TemplateMicroservice.BLL.Interfaces.Services.Person;
using TemplateMicroservice.BLL.Models.Person;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Read;

public class PersonReadHandler : IRequestHandler<PersonReadRequest, PersonDto>
{
    private readonly IPersonService _personService;
    public PersonReadHandler(IPersonService personService)
    {
        _personService = personService;
    }
    public Task<PersonDto> Handle(PersonReadRequest request, CancellationToken cancellationToken)
    {
        return _personService.Read(request.Id, cancellationToken);
    }
}
