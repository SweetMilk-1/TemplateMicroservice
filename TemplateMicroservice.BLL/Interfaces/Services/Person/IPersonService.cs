
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Interfaces.Query;
using TemplateMicroservice.Core.Models;

namespace TemplateMicroservice.BLL.Interfaces.Services.Person;

/// <summary>
/// Интерфейс сервиса для работы с людьми
/// </summary>
public interface IPersonService
{
    /// <summary>
    /// Создать пользователя
    /// </summary>
    /// <returns></returns>
    Task<int> Create(PersonDto person, CancellationToken cancellationToken);

    ///<summary>
    ///Получить данные о пользователе
    ///</summary>
    Task<PersonDto> Read(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Изменение данных человека
    /// </summary>
    /// <returns></returns>
    Task<int> Update(PersonDto person,CancellationToken cancellationToken);

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <returns></returns>
    Task<int> Delete(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить список людей (с пагинацией)
    /// </summary>
    /// <param name="page">номер страницы</param>
    /// <param name="pageCount">количество записей на странице</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginationModel<PersonDto>> GetWithPagination(IPaginationQuery paginationQuery, CancellationToken cancellationToken);
}
