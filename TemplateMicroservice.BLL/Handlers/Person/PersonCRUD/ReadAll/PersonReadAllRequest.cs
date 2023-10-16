using MediatR;
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Interfaces.Query;
using TemplateMicroservice.Core.Models;

namespace TemplateMicroservice.BLL.Handlers.Person.PersonCRUD.ReadAll;

/// <summary>
/// Модель запроса для получения списка людей
/// </summary>
public class PersonReadAllRequest : IRequest<PaginationModel<PersonDto>>, IPaginationQuery
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Количество записей на странице
    /// </summary>
    public int PageCount { get; set; } = int.MaxValue;
}
