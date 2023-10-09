
using Microsoft.EntityFrameworkCore;
using TemplateMicroservice.DAL.Entities;

namespace TemplateMicroservice.DAL.Interfaces;

/// <summary>
/// Интерфейс, определяющий коллекции, которые определюят БД
/// </summary>
public interface IHaveDbCollections
{
    DbSet<Person> People { get; }
}
