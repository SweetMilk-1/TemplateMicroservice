using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMicroservice.BLL.Interfaces.Services.Person;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Delete
{
    internal class PersonDeleteHandler : IRequestHandler<PersonDeleteRequest, int>
    {
        private readonly IPersonService _personService;

        public PersonDeleteHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public Task<int> Handle(PersonDeleteRequest request, CancellationToken cancellationToken) =>
            _personService.Delete(request.Id, cancellationToken);
    }
}
