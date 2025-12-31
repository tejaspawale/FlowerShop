using System.ComponentModel.DataAnnotations;

public class Subscription
{
    public int Id { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Mobile { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
