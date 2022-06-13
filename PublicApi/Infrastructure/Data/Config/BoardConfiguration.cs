using ApplicationCore.Entities.ScrumBoardAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
   public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("Board");
            builder.HasKey(b => b.BoardUnicalID);
            builder.Property(b => b.BoardName).IsRequired().HasMaxLength(80);
        }
    }
}
