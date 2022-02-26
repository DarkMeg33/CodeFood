using System.ComponentModel.DataAnnotations;

namespace CodeFood.Domain.Entities;

public abstract class EntityBase
{
    [Required] public Guid Id { get; set; }
    [Display(Name = "Name")] public virtual string? Title { get; set; }
    [Display(Name = "Short description")] public virtual string? Subtitle { get; set; }
    [Display(Name = "Full description")] public virtual string? Text { get; set; }
    [Display(Name = "Title image")] public virtual string? TitleImagePath { get; set; }
    [Display(Name = "SEO metatag Title")] public string? MetaTitle { get; set; }
    [Display(Name = "SEO metatag Description")] public string? MetaDescription { get; set; }
    [Display(Name = "SEO metatag Keywords")] public string? MetaKeywords { get; set; }
    [DataType(DataType.Time)] public DateTime DateAdded { get; set; }

    protected EntityBase() => DateAdded = DateTime.UtcNow;
}
