using MediatR;
using TemplateMicroservice.BLL.Models.Person;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Update;

/// <summary>
/// Модель запроса для обновления человека
/// </summary>
public class PersonUpdateRequest:IRequest<int>
{
    /// <summary>
    /// Человек
    /// </summary>
    public PersonDto Person { get; set; }
}
