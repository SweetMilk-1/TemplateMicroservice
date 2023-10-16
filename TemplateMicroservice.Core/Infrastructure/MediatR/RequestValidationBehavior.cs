using FluentValidation;
using MediatR;
using ValidationException = TemplateMicroservice.Core.Exceptions.ValidationException;

namespace TemplateMicroservice.Core.Infrastructure.MediatR;

/// <summary>
/// Класс конвейер MediatR, запускает валидацию данных
/// </summary>
/// <typeparam name="TRequest">Класс запроса</typeparam>
/// <typeparam name="TResponse">Класс результата</typeparam>
public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="validators">Список валидаторов</param>
    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// Создает объект ValidationException в случае обнаружения ошибок валидации
    /// </summary>
    /// <param name="request">Объект запроса</param>
    /// <param name="cancellationToken">Объект для прерывания выполняемой задачи</param>
    /// <param name="next">Запускает следующий запрос в конвейере</param>
    /// <returns></returns>
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<object>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToArray();

        if (failures.Length > 0)
        {
            throw new ValidationException(failures);
        }

        return next();
    }
}
