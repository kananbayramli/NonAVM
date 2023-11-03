using ECommerse.Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ECommerse.DataAccess.Persistance.Configurations;
using Common;
using ECommerse.Core.Entities;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.BaseEntityConfigure();

        builder.HasOne<AppUser>(x => x.User).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<Order>(x => x.Orders).WithOne(x => x.ShippingAddress).OnDelete(DeleteBehavior.SetNull);
    }
}

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasOne<AppUser>(x => x.User).WithOne(x => x.Basket).OnDelete(DeleteBehavior.NoAction); //CASCADE will prevent trigger below
        builder.HasMany<BasketItem>(x => x.BasketItems).WithOne(x => x.Basket).OnDelete(DeleteBehavior.NoAction); //Manage cascade with INSTEAD OF trigger
    }
}


public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany<Product>(x => x.Products).WithOne(x => x.Category).OnDelete(DeleteBehavior.SetNull);
        builder.HasIndex(x => x.Name);
    }
}

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasMany<ProductDiscount>(x => x.ProductDiscounts).WithOne(x => x.Discount).OnDelete(DeleteBehavior.Cascade);
    }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne<AppUser>(x => x.User).WithMany(x => x.Orders).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne<Shipping>(x => x.Shipping).WithMany(x => x.Orders).OnDelete(DeleteBehavior.NoAction);//SETNULL will prevent trigger above
        builder.HasOne<Tracking>(x => x.Tracking).WithOne(x => x.Order).OnDelete(DeleteBehavior.NoAction);//CASCADE will prevent trigger above
    }
}


public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.HasOne<ProductItem>(x => x.ProductItem).WithOne(x => x.OrderDetail).OnDelete(DeleteBehavior.SetNull);
    }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne<Category>(x => x.Category).WithMany(x => x.Products).OnDelete(DeleteBehavior.SetNull);
        builder.HasMany<ProductReview>(x => x.ProductReviews).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<Store>(x => x.Store).WithMany(x => x.Products).OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(x => x.Name);
        builder.HasIndex(x => x.Description);
    }
}

public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.HasMany<ProductEntry>(x => x.ProductEntries).WithOne(x => x.ProductItem).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<Media>(x => x.Medias).WithOne(x => x.ProductItem).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<BasketItem>(x => x.BasketItems).WithOne(x => x.ProductItem).OnDelete(DeleteBehavior.Cascade);

    }
}

public class ProductReviewMediaConfiguration : IEntityTypeConfiguration<ProductReviewMedia>
{
    public void Configure(EntityTypeBuilder<ProductReviewMedia> builder)
    {
        builder.HasOne<ProductReview>(x => x.ProductReview).WithMany(x => x.Medias).OnDelete(DeleteBehavior.Cascade);

    }
}
public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.HasMany<ProductReviewMedia>(x => x.Medias).WithOne(x => x.ProductReview).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<AppUser>(x => x.User).WithMany(x => x.Reviews).OnDelete(DeleteBehavior.NoAction);

    }
}

public class StoreReviewConfiguration : IEntityTypeConfiguration<StoreReview>
{
    public void Configure(EntityTypeBuilder<StoreReview> builder)
    {
        builder.HasOne<Store>(x => x.Store).WithMany(x => x.StoreReviews).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<AppUser>(x => x.User).WithMany(x => x.StoreReviews).OnDelete(DeleteBehavior.NoAction);
    }
}

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasIndex(x => x.Name);
    }
}

public class TrackingConfiguration : IEntityTypeConfiguration<Tracking>
{
    public void Configure(EntityTypeBuilder<Tracking> builder)
    {
        builder.HasIndex(x => x.TrackingNumber);
    }
}

public class PromoConfiguration : IEntityTypeConfiguration<Promo>
{
    public void Configure(EntityTypeBuilder<Promo> builder)
    {
        builder.HasOne<AppUser>(x => x.User).WithOne(x => x.Promo).OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(x => x.Code);
    }
}