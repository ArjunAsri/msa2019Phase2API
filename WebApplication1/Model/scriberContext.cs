using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Model
{
    public partial class scriberContext : DbContext
    {
        public scriberContext()
        {
        }

        public scriberContext(DbContextOptions<scriberContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:2019msaphase2.database.windows.net,1433;Initial Catalog=scriber;Persist Security Info=False;User ID=arjun;Password=2019msaphase2!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__Tasks__7C6949D14713D4A8");

                entity.Property(e => e.CourseNumber).IsUnicode(false);

                entity.Property(e => e.TaskDescription).IsUnicode(false);

                entity.Property(e => e.TaskName).IsUnicode(false);
            });
        }
    }
}
