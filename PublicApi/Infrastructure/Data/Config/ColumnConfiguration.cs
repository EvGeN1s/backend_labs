using ApplicationCore.Entities.ScrumBoardAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class ColumnConfiguration : IEntityTypeConfiguration<Column>
    {
        public void Configure(EntityTypeBuilder<Column> builder)
        {
            builder.ToTable("Column");
            builder.HasKey(c => c.ColumnUnicalID);
            builder.Property(c => c.ColumnName).IsRequired().HasMaxLength(80);
        }
    }
}
