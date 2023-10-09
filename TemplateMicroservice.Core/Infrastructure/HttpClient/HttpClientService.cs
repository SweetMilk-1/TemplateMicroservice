using System.Text.RegularExpressions;
using TemplateMicroservice.Core.Interfaces.HttpClient;
using HttpClientNet = System.Net.Http.HttpClient;
using HttpRequestException = TemplateMicroservice.Core.Exceptions.HttpRequestException;

namespace TemplateMicroservice.Core.Infrastructure.HttpClient;

/// <summary>
/// Сервис для работы со сторонними rest-сервисами
/// </summary>
public class HttpClientService : IHttpClientService
{
    private readonly HttpClientNet _httpClient;

    /// <summary>
    /// Конструктор
    /// </summary>
    public HttpClientService()
    {
        _httpClient = new HttpClientNet();
    }

    /// <summary>
    /// Возвращает ответ, полученный после отправки запроса
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    private async Task<string> CreateResponse(HttpResponseMessage response)
    {
        var data = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return data;
        }


        throw new HttpRequestException(response.StatusCode, Regex.Unescape(data));
    }

    /// <summary>
    /// Запрос на получение данных
    /// </summary>
    public async Task<string> Get(string url, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.AddHeaders(headers);
        var response = await _httpClient.SendAsync(request);
        return await CreateResponse(response);
    }

    /// <summary>
    /// Запрос на добавление данных
    /// </summary>
    public async Task<string> Post(string url, string? json = null, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.AddHeaders(headers);
        request.AddJsonContent(json);
        var response = await _httpClient.SendAsync(request);

        return await CreateResponse(response);
    }

    /// <summary>
    /// Запрос на изменение данных
    /// </summary>
    public async Task<string> Put(string url, string? json = null, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.AddHeaders(headers);
        request.AddJsonContent(json);
        var response = await _httpClient.SendAsync(request);

        return await CreateResponse(response);
    }

    /// <summary>
    /// Запрос на удаление данных
    /// </summary>
    public async Task<string> Delete(string url, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.AddHeaders(headers);
        var response = await _httpClient.SendAsync(request);

        return await CreateResponse(response);
    }

    /// <summary>
    /// Запрос с указаниемм типа запросы
    /// </summary>
    public async Task<string> Request(HttpMethod httpMethod, string url, string? json = null, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(httpMethod, url);

        if (headers != null)
        {
            request.AddHeaders(headers);
        }

        if (json != null)
        {
            request.AddJsonContent(json);
        }

        var response = await _httpClient.SendAsync(request);

        return await CreateResponse(response);
    }
}
