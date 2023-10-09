using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.DAL.Interfaces;

public interface ICommonDbContext
{
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
