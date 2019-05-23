using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Fetenashare.Catalog.Domain.Aggregates.InstitutionAggregate;
using Fetenashare.Catalog.Domain.Aggregates.QuestionAggregate;
using Fetenashare.Catalog.Domain.Aggregates.QuestionTypeAggregate;
using Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate;
using Fetenashare.Catalog.Persistence.Configurations;
using Fetenashare.Catalog.Persistence.Extensions;
using Fetenashare.Kernel.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Fetenashare.Catalog.Persistence
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction => _currentTransaction;

        public DbSet<Institution> Institutions { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        
        }

        public CatalogContext(DbContextOptions<CatalogContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InstitutionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await _mediator.DispatchDomainEventsAsync(this);

            await SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task BeginTransactionAsync()
        {
            _currentTransaction = _currentTransaction ?? await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
