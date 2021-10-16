using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LearnAPI2.Models
{
    public partial class EsemkaTodoContext : DbContext
    {
        public EsemkaTodoContext(DbContextOptions<EsemkaTodoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoItem> TodoItems { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-GNAT0A1E;Database=EsemkaTodo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.HasIndex(e => e.CreatedByEmail, "IX_TodoItems_CreatedByEmail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedByEmail).HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CreatedByEmailNavigation)
                    .WithMany(p => p.TodoItems)
                    .HasForeignKey(d => d.CreatedByEmail);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
