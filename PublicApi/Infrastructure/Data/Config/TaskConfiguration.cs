using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task = ApplicationCore.Entities.ScrumBoardAggregate.Task;

namespace Infrastructure.Data.Config
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(t => t.TaskUnicalId);
            builder.Property(t => t.TaskName).IsRequired().HasMaxLength(80);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(255);
            builder.Property(t => t.TaskPriority).IsRequired();
        }
    }
}
