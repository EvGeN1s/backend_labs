using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ApplicationCore.Entities.ScrumBoardAggregate;
using Task = ApplicationCore.Entities.ScrumBoardAggregate.Task;

namespace Infrastructure.Data
{
    public class ScrumBoardContext : DbContext
    {
        public ScrumBoardContext(DbContextOptions<ScrumBoardContext> options) 
            : base(options)
        {

        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
