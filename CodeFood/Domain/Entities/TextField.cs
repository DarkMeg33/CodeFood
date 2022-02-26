using System.ComponentModel.DataAnnotations;

namespace CodeFood.Domain.Entities;

public class TextField : EntityBase
{
    [Required] public string? CodeWord { get; set; }
    [Display(Name = "Name of page")] public override string? Title { get; set; } = "A page";
    [Display(Name = "Page content")] public override string? Text { get; set; } = "Some text";
}
