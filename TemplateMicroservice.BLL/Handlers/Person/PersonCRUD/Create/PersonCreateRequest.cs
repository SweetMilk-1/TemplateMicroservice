using MediatR;
using TemplateMicroservice.BLL.Models.Person;

namespace TemplateMicroservice.BLL.Handlers.Person.PersonCRUD.Create;

public class PersonCreateRequest : PersonDto, IRequest<int>
{
}
