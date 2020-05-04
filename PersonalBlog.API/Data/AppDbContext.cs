
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PersonalBlog.API.Models;

namespace PersonalBlog.API.Data
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        // public DbSet<CommentReply> CommentReplies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        // protected override void  OnModelCreating(ModelBuilder builder)
        // {

        // }

       public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().AddRange(entities);
        }
        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }
        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Rollback();
        }
        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new NullReferenceException("Please call `BeginTransaction()` method first.");
            }
            _transaction.Commit();
        }
        public override void Dispose()
        {
            _transaction?.Dispose();
            base.Dispose();
        }
        public void ExecuteSqlInterpolatedCommand(FormattableString query)
        {
            Database.ExecuteSqlInterpolated(query);
        }
        public void ExecuteSqlRawCommand(string query, params object[] parameters)
        {
            Database.ExecuteSqlRaw(query, parameters);
        }

        // public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
        // {
        //     var value = this.Entry(entity).Property(propertyName).CurrentValue;
        //     return value != null
        //         ? (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)
        //         : default;
        // }

        // public object GetShadowPropertyValue(object entity, string propertyName)
        // {
        //     return this.Entry(entity).Property(propertyName).CurrentValue;
        // }
        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Update(entity);
        }
        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().RemoveRange(entities);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.DetectChanges();

            // beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges(); //NOTE: changeTracker.Entries<T>() will call it automatically.

            // beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChanges();
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            // beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            // beforeSaveTriggers();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        // private void beforeSaveTriggers()
        // {
        //     validateEntities();
        //     setShadowProperties();
        // }

        // private void setShadowProperties()
        // {
        //     // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
        //     var httpContextAccessor = this.GetService<IHttpContextAccessor>();
        //     ChangeTracker.SetAuditableEntityPropertyValues(httpContextAccessor);
        // }

        // private void validateEntities()
        // {
        //     var errors = this.GetValidationErrors();
        //     if (!string.IsNullOrWhiteSpace(errors))
        //     {
        //         // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
        //         var loggerFactory = this.GetService<ILoggerFactory>();
        //         var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
        //         logger.LogError(errors);
        //         throw new InvalidOperationException(errors);
        //     }
        // }

      

       
    }
}