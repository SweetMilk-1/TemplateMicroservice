using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateMicroservice.DAL.Entities;

namespace TemplateMicroservice.DAL.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        /// <summary>
        /// Класс для настройки сущности (в контексте EF Core)
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Person> builder)
        {
        }
    }
}
