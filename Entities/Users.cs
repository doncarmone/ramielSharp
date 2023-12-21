using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Users
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [Column("id_role")]
    public int IdRole { get; set; }
    public bool Banned { get; set; }
    
}