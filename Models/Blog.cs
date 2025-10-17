using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_api.Models;

public class Blog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public String Title { get; set; }
    [Required]
    public String Content { get; set; }
    [Required]
    public String UserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
