using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Agriculture.Shared.Domain.Abstractions;

namespace Agriculture.Shared.Infrastructure.Persistences.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {

            if (eventData.Context != null)
            {
                var changeTracker = eventData.Context.ChangeTracker;
                var currentTime = DateTime.UtcNow;

                UpdateAddedEntriesTimestamp(changeTracker, currentTime);
                UpdateModifiedEntriesTimestamp(changeTracker, currentTime);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private void UpdateAddedEntriesTimestamp(ChangeTracker changeTracker, DateTime currentTime)
        {
            var entries = changeTracker
                .Entries<IAuditableInfo>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                var entity = entry.Entity;
                entity.CreatedAt = currentTime;
            }
        }

        private void UpdateModifiedEntriesTimestamp(ChangeTracker changeTracker, DateTime currentTime)
        {
            var entries = changeTracker
                .Entries<IAuditableInfo>()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = entry.Entity;
                entity.UpdatedAt = currentTime;
            }
        }
    }
}
