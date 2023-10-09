using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TemplateMicroservice.DAL.Entities;
using TemplateMicroservice.DAL.Interfaces;

namespace TemplateMicroservice.DAL;

public class AppDbContext : DbContext, IAppDbContext
{ 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    /// <summary>
    /// Люди
    /// </summary>
    public DbSet<Person> People => Set<Person>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
