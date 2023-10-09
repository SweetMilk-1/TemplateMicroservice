using AutoMapper;

namespace TemplateMicroservice.Core.Interfaces.AutoMapper;

/// <summary>
/// Интерфейс используется в случае если необходимо настроить поля для преобразовании одного класса в другой при помощи AutoMapper
/// </summary>
public interface IHaveCustomMapping
{
    /// <summary>
    /// Настраивает поля для преобразования
    /// </summary>
    /// <param name="configuration"></param>
    void CreateMappings(Profile configuration);
}
