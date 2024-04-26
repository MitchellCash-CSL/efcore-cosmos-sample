using System.ComponentModel.DataAnnotations;

namespace Cat.Api.Entities;

public class Kitten
{
    [Key]
    public required Guid Id { get; init; }

    [MaxLength(100)]
    public required string Name { get; set; }

    public required DateTime CreatedAt { get; set; }
}
