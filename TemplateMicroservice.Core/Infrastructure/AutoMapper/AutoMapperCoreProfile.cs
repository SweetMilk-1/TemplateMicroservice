using AutoMapper;
using System.Reflection;

namespace TemplateMicroservice.Core.Infrastructure.AutoMapper
{
    /// <summary>
    /// Класс, которыей добавляет маппер в проект
    /// </summary>
    public class AutoMapperCoreProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AutoMapperCoreProfile()
        {
            MapperProfileHelper.MapRegister(this, Assembly.GetExecutingAssembly());
        }
    }
}
