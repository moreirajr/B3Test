using B3Test.Domain.Entities;
using B3Test.Domain.SeedWork;
using B3Test.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace B3Test.Infrastructure.Persistence
{
    public class B3TestContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "dbo";
        private readonly IMediator _mediator;

        public B3TestContext(DbContextOptions<B3TestContext> dbContextOptions, IMediator mediator)
            : base(dbContextOptions)
        {
            _mediator = mediator;
            ChangeTracker.LazyLoadingEnabled = false;
            CreateDatabaseIfNotExists();
        }

        private void CreateDatabaseIfNotExists()
        {
            var database = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!;
            if (!database.Exists())
                Database.EnsureCreated();
        }

        #region DbSets
        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
