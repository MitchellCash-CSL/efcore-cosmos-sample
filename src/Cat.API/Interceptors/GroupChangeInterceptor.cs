using Cat.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Cat.Api.Interceptors;

public class GroupChangeInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var entries = eventData.Context!.ChangeTracker.Entries<Kitten>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                // Intercept new Kitten creation
                var newKitten = entry.Entity;
                Console.WriteLine($"Creating new Kitten: {newKitten.Name}");
            }
            else if (entry.State == EntityState.Modified)
            {
                // Intercept Kitten update
                var modifiedKitten = entry.Entity;
                Console.WriteLine($"Updating Kitten: {modifiedKitten.Name}");

                // Access old values
                var oldValues = entry.OriginalValues;
                var oldName = oldValues.GetValue<string>(nameof(Entities.Kitten.Name));

                // Access new values
                var newValues = entry.CurrentValues;
                var newName = newValues.GetValue<string>(nameof(Entities.Kitten.Name));

                Console.WriteLine($"Old values - Name: {oldName}");
                Console.WriteLine($"New values - Name: {newName}");
            }
        }

        return result;
    }
}
