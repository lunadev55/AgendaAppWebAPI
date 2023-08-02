using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaAPI.Models;

[Table("Agenda")]
public class Agenda
{
    [Key]
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(320)]
    [Required]
    public string? Email { get; set; } = string.Empty;

    [MaxLength(20)]
    [Required]
    public string Phonenumber { get; set; } = string.Empty;

    [NotMapped]
    public string Message { get; set; } = string.Empty;
}
