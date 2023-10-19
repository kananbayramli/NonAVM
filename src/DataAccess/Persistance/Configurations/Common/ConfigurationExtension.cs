using ECommerse.Core.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerse.DataAccess.Persistance.Configurations.Common;

public static class ConfigurationExtension
{
    public static EntityTypeBuilder<TEntity> BaseEntityConfigure<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        builder.HasKey(x => x.Id);
        //builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        return builder;
    }
}