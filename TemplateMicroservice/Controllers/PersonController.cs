﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using TemplateMicroservice.BLL.Handlers.PersonCRUD.Create;
using TemplateMicroservice.BLL.Handlers.PersonCRUD.Delete;
using TemplateMicroservice.BLL.Handlers.PersonCRUD.Read;
using TemplateMicroservice.BLL.Handlers.PersonCRUD.Update;
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Models;

namespace TemplateMicroservice.Controllers;

/// <summary>
/// Контроллер для работы с людьми
/// </summary>
public class PersonController : CustomController
{
    /// <summary>
    /// Добавление человека
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public Task<IActionResult> Create(PersonCreateRequest request) => HandleRequest(request);

    /// <summary>
    /// Получить информацию о человеке
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(PersonDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public Task<IActionResult> Read([FromRoute] PersonReadRequest request) => HandleRequest(request);

    /// <summary>
    /// Изменить информацию о человеке
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{Id}")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public Task<IActionResult> Update([FromRoute] int Id, [FromBody] PersonUpdateRequest request) {
        request.Person.Id = Id;
        return HandleRequest(request);
    }

    /// <summary>
    /// Удалить человека
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
    public Task<IActionResult> Delete([FromRoute] PersonDeleteRequest request) => HandleRequest(request);
}
