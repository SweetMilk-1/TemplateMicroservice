using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMicroservice.BLL.Handlers.PersonCRUD.Delete;

/// <summary>
/// Модель запроса для удаления человека
/// </summary>
public class PersonDeleteRequest:IRequest<int>
{
    /// <summary>
    /// ID человека
    /// </summary>
    public int Id { get; set; } 
}

