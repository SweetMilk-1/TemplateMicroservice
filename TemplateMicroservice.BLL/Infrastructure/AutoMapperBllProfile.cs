using AutoMapper;
using System.Reflection;
using TemplateMicroservice.Core.Infrastructure.AutoMapper;

namespace TemplateMicroservice.BLL.Infrastructure
{
    /// <summary>
    /// Класс, которыей добавляет маппер в проект
    /// </summary>
    public class AutoMapperBllProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AutoMapperBllProfile()
        {
            MapperProfileHelper.MapRegister(this, Assembly.GetExecutingAssembly());
        }
    }
}
