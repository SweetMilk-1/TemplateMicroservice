using TemplateMicroservice.BLL.Models.Person;
using TemplateMicroservice.BLL.Services.Person;
using TemplateMicroservice.Core.Exceptions;
using TemplateMicroservice.Tests.DbContext.Helpers;
using TemplateMicroservice.Tests.Infrastructure.AutoMapper;

namespace TemplateMicroservice.Tests.Tests.Services.Person;

public class PersonServiceTests
{
    private Fixture _fixture;
    public PersonServiceTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public async void ReadPerson_WhenPersonExists_NotNull()
    {
        // Arrange
        var mapper = AutoMapperHelper.GetMapper();
        var context = AppDbContextCreator.Context;
        var personService = new PersonService(context, mapper);
        var cancelationToken = new CancellationToken();
        
        // Act
        var res = await personService.Read(1, cancelationToken);

        // Assert
        Assert.NotNull(res);
        Assert.Equivalent(res.Id, 1);
    }

    [Fact]
    public async void ReadPerson_WhenPersonNotExists_ThrowsNotFoundException()
    {
        // Arrange
        var mapper = AutoMapperHelper.GetMapper();
        var context = AppDbContextCreator.Context;
        var personService = new PersonService(context, mapper);
        var cancelationToken = new CancellationToken();

        // Act

        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await personService.Read(100, cancelationToken));
    }


    [Fact]
    public async void CreatePerson_WhenNewPerson_Accepted()
    {
        // Arrange
        var mapper = AutoMapperHelper.GetMapper();
        var context = AppDbContextCreator.Context;
        var personService = new PersonService(context, mapper);
        var cancelationToken = new CancellationToken();

        var person = new PersonDto
        {
            Name = "Name",
            Age = 1
        };

        // Act
        var res = await personService.Create(person, cancelationToken);

        // Assert
        var expected = context.People.FirstOrDefault(item => item.Id == res);
        Assert.True(ComparePersonEntityAndPersonDto(person, expected));
    }

    [Fact]
    public async void UpdatePerson_WhenPersonExists_Accepted()
    {
        // Arrange
        var mapper = AutoMapperHelper.GetMapper();
        var context = AppDbContextCreator.Context;
        var personService = new PersonService(context, mapper);
        var cancelationToken = new CancellationToken();

        var person = new PersonDto
        {
            Id = 1,
            Name = "Name",
            Age = 1
        };

        // Act
        var res = await personService.Update(person, cancelationToken);

        // Assert
        var expected = context.People.FirstOrDefault(item => item.Id == res);
        Assert.True(ComparePersonEntityAndPersonDto(person, expected));
    }

    [Fact]
    public async void UpdatePerson_WhenPersonNotExists_ThrowsNotFoundException()
    {
        // Arrange
        var mapper = AutoMapperHelper.GetMapper();
        var context = AppDbContextCreator.Context;
        var personService = new PersonService(context, mapper);
        var cancelationToken = new CancellationToken();

        var person = new PersonDto
        {
            Id = 100,
            Name = "Name",
            Age = 1
        };
        // Act

        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await personService.Update(person, cancelationToken));
    }

    [Fact]
    public async void DeletePerson_WhenPersonExists_Accepted()
    {
        // Arrange
        var mapper = AutoMapperHelper.GetMapper();
        var context = AppDbContextCreator.Context;
        var personService = new PersonService(context, mapper);
        var cancelationToken = new CancellationToken();

        var person = new DAL.Entities.Person
        {
            Name = "Name",
            Age = 1
        };
        context.People.Add(person);
        await context.SaveChangesAsync(cancelationToken);
        
        // Act
        var res = await personService.Delete(person.Id, cancelationToken);

        // Assert
        var expected = context.People.FirstOrDefault(item => item.Id == res);
        Assert.Null(expected);
    }

    [Fact]
    public async void DeletePerson_WhenPersonNotExists_ThrowsNotFoundException()
    {
        // Arrange
        var mapper = AutoMapperHelper.GetMapper();
        var context = AppDbContextCreator.Context;
        var personService = new PersonService(context, mapper);
        var cancelationToken = new CancellationToken();

        // Act

        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () => await personService.Delete(100, cancelationToken));
    }
    private bool ComparePersonEntityAndPersonDto(PersonDto person, DAL.Entities.Person? expected)
    {
        return person.Name.Equals(person.Name) && person.Age == person.Age;
    }
}
