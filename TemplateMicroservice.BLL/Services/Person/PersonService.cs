﻿using AutoMapper;
using System.Net;
using TemplateMicroservice.BLL.Interfaces.Services.Person;
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Exceptions;
using TemplateMicroservice.DAL.Interfaces;
using PersonEntity = TemplateMicroservice.DAL.Entities.Person;

namespace TemplateMicroservice.BLL.Services.Person;

internal class PersonService : IPersonService
{
    readonly IAppDbContext _appDbContext;
    readonly IMapper _mapper;
    public PersonService(IAppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
    public async Task<int> Create(PersonDto person, CancellationToken cancellationToken)
    {
        var personEntity = _mapper.Map<PersonEntity>(person);
        await _appDbContext.People.AddAsync(personEntity);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return personEntity.Id;
    }


    public async Task<int> Update(PersonDto person, CancellationToken cancellationToken)
    { 
        var personDb = _appDbContext.People.Where(item => item.Id == person.Id).FirstOrDefault();
        if (person == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, "Человек не найден");
        }
        personDb.Age = person.Age;
        personDb.Name = person.Name;
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return personDb.Id;
    }

    public async Task<PersonDto> Read(int id, CancellationToken cancellationToken)
    {
        var person = _appDbContext.People.Where(item => item.Id == id).FirstOrDefault();
        if (person == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, "Человек не найден");
        }
        return _mapper.Map<PersonDto>(person);
    }

    public async Task<int> Delete(int id, CancellationToken cancellationToken)
    {
        var person = _appDbContext.People.Where(item => item.Id == id).FirstOrDefault();
        if (person == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, "Человек не найден");
        }
        _appDbContext.People.Remove(person);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return person.Id;
    }
}
