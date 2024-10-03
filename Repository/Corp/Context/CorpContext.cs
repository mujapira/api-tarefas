using Microsoft.EntityFrameworkCore;
using tarefas.Corp.Entities;

namespace tarefas.Corp.Context
{
    public partial class CorpContext : DbContext
    {
        public CorpContext() { }

        public CorpContext(DbContextOptions<CorpContext> options) : base(options) { }

        public virtual DbSet<ChoreEntity> Chores { get; set; }
        public virtual DbSet<SessionEntity> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<ChoreEntity>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<SessionEntity>(entity =>
            {
                entity.ToTable("Sessions");
                entity.HasKey(e => e.SessionId);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
