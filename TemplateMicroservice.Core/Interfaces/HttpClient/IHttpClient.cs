using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.Core.Interfaces.HttpClient;

/// <summary>
/// Интерфейс отправки сообщений стороннему сервису
/// </summary>
public interface IHttpClientService
{
    /// <summary>
    /// Запрос на получение данных
    /// </summary>
    /// <param name="url">Адрес</param>
    /// <param name="headers">Заголовки</param>
    /// <returns></returns>
    Task<string> Get(string url, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Запрос на добавление данных
    /// </summary>
    /// <param name="url">Адрес</param>
    /// <param name="json">Передаваемые json-данные</param>
    /// <param name="headers">Заголовки</param>
    /// <returns></returns>
    Task<string> Post(string url, string? json = null, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Запрос на изменение данных
    /// </summary>
    /// <param name="url">Адрес</param>
    /// <param name="json">Передаваемые json-данные</param>
    /// <param name="headers">Заголовки</param>
    /// <returns></returns>
    Task<string> Put(string url, string? json = null, Dictionary<string, string>? headers = null);

    /// <summary>
    /// Запрос на удаление данных
    /// </summary>
    /// <param name="url">Адрес</param>
    /// <param name="headers">Заголовки</param>
    /// <returns></returns>
    Task<string> Delete(string url, Dictionary<string, string>? headers = null);
    
    /// <summary>
    /// Запрос с указаниемм типа запросы
    /// </summary>
    Task<string> Request(HttpMethod httpMethod, string url, string? json = null, Dictionary<string, string>? headers = null);
}


