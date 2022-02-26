using System.ComponentModel.DataAnnotations;

namespace CodeFood.Domain.Entities;

public class ServiceItem : EntityBase
{
    [Required(ErrorMessage = "Enter service name")]
    [Display(Name = "Name")] public override string? Title { get; set; }
    [Display(Name = "Short description")] public override string? Subtitle { get; set; }
    [Display(Name = "Full description")] public override string? Text { get; set; }
}
