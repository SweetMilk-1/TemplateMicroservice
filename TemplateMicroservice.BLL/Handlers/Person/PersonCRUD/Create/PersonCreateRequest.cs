using MediatR;
using TemplateMicroservice.BLL.Models.Person;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Create
{

    public class PersonCreateRequest:IRequest<int>
    {
        ///<summary>
        ///Человек
        ///</summary>
        public PersonDto Person { get; set; }
    }
}
