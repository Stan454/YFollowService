using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet for the Follow entity
    public Microsoft.EntityFrameworkCore.DbSet<Follow> Follows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the Follow entity (optional)
        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(f => f.Id);
            entity.Property(f => f.FollowerId).IsRequired();
            entity.Property(f => f.UserId).IsRequired();
        });
    }
}
