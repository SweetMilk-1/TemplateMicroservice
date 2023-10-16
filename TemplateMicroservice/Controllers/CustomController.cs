using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TemplateMicroservice.Controllers;

/// <summary>
/// Базовый контроллер для других контроллеов
/// </summary>
[ApiController]
[Route("api/[controller]")]

public class CustomController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

    /// <summary>
    /// Функция, запускающая обработку запроса в Handler-е и возвращающая ответ (если все прошло нормально)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    protected async Task<IActionResult> OkMediatorResponse(object request) =>
        Ok(await Mediator.Send(request));
}
