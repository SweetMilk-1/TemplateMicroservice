using AutoMapper;
using System.Reflection;

namespace TemplateMicroservice.Core.Infrastructure.AutoMapper
{
    /// <summary>
    /// Класс, которыей добавляет маппер в проект
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AutoMapperProfile()
        {
            MapperProfileHelper.MapRegister(this, Assembly.GetExecutingAssembly());
        }
    }
}
