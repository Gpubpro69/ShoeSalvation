using Microsoft.EntityFrameworkCore;
using ShoeSalvation.Domain.Entities;
namespace ShoeSalvation.Repository.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<PriceHistory> PriceHistories { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Return> Returns { get; set; }
    public DbSet<StockAdjustment> StockAdjustments { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<WishlistItem> WishlistItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Sneakers" });

        modelBuilder.Entity<SubCategory>().HasData(
           new SubCategory {Id=1, CategoryId = 1, Name = "Ankle" });
        modelBuilder.Entity<Brand>().HasData(
         new Brand { Id = 1, Name = "Nike", CreatedAt = new DateTime(2024, 1, 1) });
        // Disable cascade delete globally
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        modelBuilder.Entity<ProductVariant>(e => {
            e.Property(p => p.Mrp).HasPrecision(18, 2);
            e.Property(p => p.SellingPrice).HasPrecision(18, 2);
        });

        modelBuilder.Entity<PriceHistory>(e => {
            e.Property(p => p.OldMrp).HasPrecision(18, 2);
            e.Property(p => p.NewMrp).HasPrecision(18, 2);
            e.Property(p => p.OldSellingPrice).HasPrecision(18, 2);
            e.Property(p => p.NewSellingPrice).HasPrecision(18, 2);
        });
        modelBuilder.Entity<Order>(e => {
            e.Property(p => p.TotalAmount).HasPrecision(18, 2);
        });
        modelBuilder.Entity<OrderItem>(e => {
            e.Property(p => p.PriceAtPurchase).HasPrecision(18, 2);
            e.Property(p => p.MrpAtPurchase).HasPrecision(18, 2);
        });
    }
}



