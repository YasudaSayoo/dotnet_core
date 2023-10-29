using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
class CatConfig : IEntityTypeConfiguration<Cat>
{
    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.ToTable("T_Cats");
        // pgsql
        builder.Ignore(c=>c.Version);
        builder.Property(c=>c.Name2).HasColumnName("NameTwo").HasColumnType("char(10)");
        // builder.HasIndex(u => u.Email).IsUnique();
    }
}