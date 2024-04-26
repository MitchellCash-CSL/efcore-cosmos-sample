using Cat.Api.Constants;
using Cat.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cat.Api.Persistence.EntityConfigurations;

public class KittenEntityTypeConfiguration : IEntityTypeConfiguration<Kitten>
{
    public void Configure(EntityTypeBuilder<Kitten> builder)
    {
        builder
            .ToContainer(CosmosDbConstants.AnimalsContainerName)
            .HasPartitionKey(c => c.Id);
    }
}
