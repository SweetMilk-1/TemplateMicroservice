namespace TemplateMicroservice.Core.Interfaces.AutoMapper;

/// <summary>
/// Интерфейс для указания целевого класса преобразования для AutoMapper
/// Используется в случае если нет необходимости настройки полей при преобразовании одного класса в другой
/// </summary>
/// <typeparam name="TEntity">Класс-источник</typeparam>
public interface IMapTo<TEntity> where TEntity : class
{
}
