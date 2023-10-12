using MediatR;
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Interfaces.Query;
using TemplateMicroservice.Core.Models;

namespace TemplateMicroservice.BLL.Handlers.Person.GetPeople;

/// <summary>
/// Модель запроса для получения списка людей
/// </summary>
public class GetPeopleRequest : IRequest<PaginationModel<PersonDto>>, IPaginationQuery
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Количество записей на странице
    /// </summary>
    public int PageCount { get; set; }
}
