using TemplateMicroservice.DAL.Entities;

namespace TemplateMicroservice.Tests.DbContext.Helpers
{
    public static class PersonHelpers
    {
        public static IEnumerable<Person> GetPeople()
        {
            var fixture = new Fixture();
            var person1 = fixture.Build<Person>().With(x => x.Id, () => 1).Create();
            var person2 = fixture.Build<Person>().With(x => x.Id, () => 2).Create();
            var person3 = fixture.Build<Person>().With(x => x.Id, () => 3).Create();
            return new Person[] { person1, person2, person3 };
        }
    }
}
