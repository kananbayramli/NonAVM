using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerse.DataAccess.Persistance;

public class ECommerseDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public ECommerseDbContext(DbContextOptions<ECommerseDbContext> options) : base(options) { }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDiscount> ProductDiscounts { get; set; }
    public DbSet<ProductEntry> ProductEntries { get; set; }
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ProductReviewMedia> ProductReviewMedias { get; set; }
    public DbSet<Promo> Promos { get; set; }
    public DbSet<Shipping> Shippings { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreReview> StoreReviews { get; set; }
    public DbSet<Tracking> Trackings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
