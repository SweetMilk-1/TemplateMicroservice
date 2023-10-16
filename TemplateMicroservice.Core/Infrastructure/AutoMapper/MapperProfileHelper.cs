using AutoMapper;
using System.Reflection;
using TemplateMicroservice.Core.Interfaces.AutoMapper;

namespace TemplateMicroservice.Core.Infrastructure.AutoMapper;

/// <summary>
/// Класс для поиска объектов преобразования
/// </summary>
public static class MapperProfileHelper
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public static void MapRegister(Profile profile, Assembly assembly)
    {
        LoadStandardMappings(profile, assembly);
        LoadCustomMappings(profile, assembly);
    }

    private static void LoadStandardMappings(Profile profile, Assembly assembly)
    {
        var mapsFrom = LoadStandardMappings(assembly);

        foreach (var map in mapsFrom)
        {
            profile.CreateMap(map.Source, map.Destination).ReverseMap();
        }
    }

    private static void LoadCustomMappings(Profile profile,Assembly assembly)
    {
        var mapsFrom = LoadCustomMappings(assembly);

        foreach (var map in mapsFrom)
        {
            map.CreateMappings(profile);
        }
    }
    /// <summary>
    /// Ищет и возвращает классы для преобразования (помеченные интерфейсом IMapFrom)
    /// Используется в случае если нет необходимости настройки полей при преобразовании одного класса в другой
    /// </summary>
    /// <param name="rootAssembly">Объект сборки в котором будет происходить поиск</param>
    /// <returns></returns>
    private static IList<Map> LoadStandardMappings(Assembly rootAssembly)
    {
        var types = rootAssembly.GetExportedTypes();

        var mapsFrom = (
                from type in types
                from instance in type.GetInterfaces()
                where
                    instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                    !type.IsAbstract &&
                    !type.IsInterface
                select new Map
                {
                    Source = type.GetInterfaces().First().GetGenericArguments().First(),
                    Destination = type
                }).ToList();

        return mapsFrom;
    }

    /// <summary>
    /// Ищет и возвращает классы для преобразования (помеченные интерфейсом IHaveCustomMapping)
    /// Используется в случае если необходимо настроить поля для преобразовании одного класса в другой
    /// </summary>
    /// <param name="rootAssembly">Объект сборки в котором будет происходить поиск</param>
    /// <returns></returns>
    private static IList<IHaveCustomMapping> LoadCustomMappings(Assembly rootAssembly)
    {
        var types = rootAssembly.GetExportedTypes();

        var mapsFrom = (
                from type in types
                from instance in type.GetInterfaces()
                where
                    typeof(IHaveCustomMapping).IsAssignableFrom(type) &&
                    !type.IsAbstract &&
                    !type.IsInterface
                select (IHaveCustomMapping)Activator.CreateInstance(type)).ToList();

        return mapsFrom;
    }
}
