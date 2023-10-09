
using TemplateMicroservice.BLL.Models.Person;

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
}
