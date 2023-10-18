using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TemplateMicroservice.DAL;
using TemplateMicroservice.DAL.Interfaces;

namespace TemplateMicroservice.Tests.DbContext.Helpers
{
    public static class AppDbContextHelper
    {
        private static IAppDbContext _context = null;
        public static IAppDbContext GetContext()
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


        private static void FillDbContext()
        {
            _context.People.AddRange(PersonHelpers.GetPeople());

            _context.SaveChangesAsync(new CancellationToken()).Wait();
        }
    }
}
