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
        await Assert.ThrowsAsync<NotFoundException>(async () => await personService.Read(4, cancelationToken));
    }
}
