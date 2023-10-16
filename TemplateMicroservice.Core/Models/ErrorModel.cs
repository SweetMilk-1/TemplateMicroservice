using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.Core.Models;

/// <summary>
/// Модель данных ошибки
/// </summary>
public class ErrorModel
{
    /// <summary>
    /// Общее сообщение
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Дополнительные данные
    /// </summary>
    public object? Data { get; set; }
}
