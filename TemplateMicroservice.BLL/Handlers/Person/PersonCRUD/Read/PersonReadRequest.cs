using MediatR;
using TemplateMicroservice.BLL.Models.Person;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Read;

/// <summary>
/// Модель запроса для получения информации о человеке
/// </summary>
public class PersonReadRequest : IRequest<PersonDto>
{
    /// <summary>
    /// ID человека
    /// </summary>
    public int Id { get; set; }
}
