using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class SuperHero
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(30)]
    [Column(TypeName = "varchar(30)")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Place { get; set; } = string.Empty;
}