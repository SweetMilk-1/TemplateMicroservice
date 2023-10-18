
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TemplateMicroservice.DAL.Entities;

namespace TemplateMicroservice.DAL.Interfaces;

/// <summary>
/// Интерфейс, определяющий коллекции, которые определюят БД
/// </summary>
public interface IAppDbContext
{
    /// <summary>
    /// Таблица с физ.лицами
    /// </summary>
    DbSet<Person> People { get; }

    /// <summary>
    /// Сохраняет изменения
    /// </summary>
    /// <param name="cancellationToken">Объект для прерывания выполняемой задачи</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Поиск и предоставление доступа к сущности
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <returns></returns>
    EntityEntry Entry(object entity);

    /// <summary>
    /// Фасад для доступа к операторам
    /// </summary>
    /// <value></value>
    DatabaseFacade Database { get; }
}
