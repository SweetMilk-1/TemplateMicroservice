namespace TemplateMicroservice.Core.Interfaces.Query
{
    /// <summary>
    /// Интерфейс для получение записей с пагинацией
    /// </summary>
    public interface IPaginationQuery
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// Количество записей на одной странице
        /// </summary>
        public int PageCount { get; }
    }
}
