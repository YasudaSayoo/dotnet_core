using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        /*
        if (isMySQL())
        {
            builder.ToTable("M_Books");
        }
        else if (isPgSQL())
        {
            builder.ToTable("P_Books");
        }
        */
        // table name
        builder.ToTable("T_Books");
        // pgsql
        // Title    character varying   50
        builder.Property(b=>b.Title).HasMaxLength(50).IsRequired();
        builder.Property(b=>b.AuthorName).HasMaxLength(20).IsRequired();
    }
}