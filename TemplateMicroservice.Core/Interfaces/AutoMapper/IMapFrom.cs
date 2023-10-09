namespace TemplateMicroservice.Core.Interfaces.AutoMapper;

/// <summary>
/// Интерфейс для указания целевого класса преобразования для AutoMapper
/// Используется в случае если нет необходимости настройки полей при преобразовании одного класса в другой
/// </summary>
/// <typeparam name="TEntity">Целевой класс</typeparam>
public interface IMapFrom<TEntity> where TEntity : class
{
}

