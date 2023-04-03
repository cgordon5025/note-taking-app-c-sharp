using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace noteTakingApp.Models
{
        public partial class NoteWebDbContext : DbContext
        {
            public NoteWebDbContext()
            {
            }
            public NoteWebDbContext(DbContextOptions<NoteWebDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-E410567\\MTTMBPSQLSVR;Initial Catalog=NoteWebDb;Persist Security Info=True;User ID=sa;Password=a");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();
                //entity.Property(e => e.Date).HasColumnType("datetime");
            });
        }
    }

}
