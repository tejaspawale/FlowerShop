using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAssessment.WebMVC.Models;

public class Home
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public string? ImageUrl { get; set; }
}