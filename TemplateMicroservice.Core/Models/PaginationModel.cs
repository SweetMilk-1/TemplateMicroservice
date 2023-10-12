namespace TemplateMicroservice.Core.Models;

/// <summary>
/// Модель данных для отправки ответа с пагинацией клиенту 
/// </summary>
/// <typeparam name="T"></typeparam>
public class PaginationModel<T> where T : class
{
    /// <summary>
    /// Список записей
    /// </summary>
    public IEnumerable<T> Records { get; set; }
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Количество записей на одной странице
    /// </summary>
    public int Total { get; set; }

    /// <summary>
    /// Общее количество записей
    /// </summary>
    public int PageCount { get; set; }
}
