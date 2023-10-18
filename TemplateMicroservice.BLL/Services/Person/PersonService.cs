using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TemplateMicroservice.BLL.Interfaces.Services.Person;
using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.Core.Exceptions;
using TemplateMicroservice.Core.Interfaces.Query;
using TemplateMicroservice.Core.Models;
using TemplateMicroservice.DAL.Interfaces;
using PersonEntity = TemplateMicroservice.DAL.Entities.Person;

namespace TemplateMicroservice.BLL.Services.Person;

public class PersonService : IPersonService
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
        if (personDb == null)
        {
            throw new NotFoundException("Человек не найден");
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
            throw new NotFoundException("Человек не найден");
        }
        return _mapper.Map<PersonDto>(person);
    }

    public async Task<int> Delete(int id, CancellationToken cancellationToken)
    {
        var person = _appDbContext.People.Where(item => item.Id == id).FirstOrDefault();
        if (person == null)
        {
            throw new NotFoundException("Человек не найден");
        }
        _appDbContext.People.Remove(person);
        await _appDbContext.SaveChangesAsync(cancellationToken);
        return person.Id;
    }

    public async Task<PaginationModel<PersonDto>> GetWithPagination(IPaginationQuery paginationQuery, CancellationToken cancellationToken)
    {
        var total = await _appDbContext.People.AsQueryable().CountAsync(cancellationToken);
        var query = await _appDbContext.People
            .Skip(paginationQuery.PageCount * (paginationQuery.Page - 1))
            .Take(paginationQuery.PageCount)
            .ToArrayAsync(cancellationToken);
        var records = _mapper.Map<IEnumerable<PersonEntity>, IEnumerable<PersonDto>>(query);
        return new PaginationModel<PersonDto>
        {
            Records = records,
            Page = (int)paginationQuery.Page,
            PageCount = (int)paginationQuery.PageCount,
            Total = total
        };
    }
}

