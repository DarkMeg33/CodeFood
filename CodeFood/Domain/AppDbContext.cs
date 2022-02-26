using CodeFood.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeFood.Domain;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TextField>? TextFields { get; set; }
    public DbSet<ServiceItem>? ServiceItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "91BA577B-5D85-423B-9C29-DE294E08628E",
            Name = "admin",
            NormalizedName = "ADMIN"
        });

        builder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "F4E6BB68-5522-4BB0-9785-CA7D5C83723C",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "foodcode@email.com",
            NormalizedEmail = "FOODCODE@EMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
            SecurityStamp = string.Empty
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "91BA577B-5D85-423B-9C29-DE294E08628E",
            UserId = "F4E6BB68-5522-4BB0-9785-CA7D5C83723C"
        });

        builder.Entity<TextField>().HasData(new TextField()
        {
            Id = new Guid("6649A9F3-AB72-49BF-84C9-1F0C70F4B929"),
            CodeWord = "PageIndex",
            Title = "Main"
        });

        builder.Entity<TextField>().HasData(new TextField()
        {
            Id = new Guid("C6A8EB5A-EF29-4D76-B615-11BF2E74BA3D"),
            CodeWord = "PageServices",
            Title = "Services"
        });

        builder.Entity<TextField>().HasData(new TextField()
        {
            Id = new Guid("5199FDF7-917C-4B76-B124-DBC8389A202D"),
            CodeWord = "PageContacts",
            Title = "Contacts"
        });
    }
}
