using Cat.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cat.Api.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Kitten> Kittens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default);
}
