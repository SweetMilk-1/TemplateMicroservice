using TemplateMicroservice.Core.Interfaces.AutoMapper;
using PersonEntity = TemplateMicroservice.DAL.Entities.Person;

namespace TemplateMicroservice.BLL.Models.Person;

public class PersonDto:IMapFrom<PersonEntity>
{
    /// <summary>
    /// Номер
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }
}
