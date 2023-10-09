using AutoMapper;
using System.Reflection;
using TemplateMicroservice.Core.Infrastructure.AutoMapper;

namespace TemplateMicroservice.BLL
{
    /// <summary>
    /// Класс, которыей добавляет маппер в проект
    /// </summary>
    public class BllAutoMapperProfile : Profile
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public BllAutoMapperProfile() {
            MapperProfileHelper.MapRegister(this, Assembly.GetExecutingAssembly());
        }
    }
}
