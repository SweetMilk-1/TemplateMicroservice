using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TemplateMicroservice.DAL;
using TemplateMicroservice.DAL.Interfaces;

namespace TemplateMicroservice.Tests.DbContext.Helpers
{
    public static class AppDbContextCreator
    {
        private static IAppDbContext _context = null;
        public static IAppDbContext Context { get
            {
                if (_context == null)
                {
                    var builder = new DbContextOptionsBuilder<AppDbContext>();
                    builder.UseInMemoryDatabase("TEST_DATABASE")
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

                    var options = builder.Options;

                    _context = new AppDbContext(options);

                    FillDbContext();
                }
                return _context;
            }
        }

        private static void FillDbContext()
        {
            Context.People.AddRange(PersonHelpers.GetPeople());

            Context.SaveChangesAsync(new CancellationToken()).Wait();
        }
    }
}
