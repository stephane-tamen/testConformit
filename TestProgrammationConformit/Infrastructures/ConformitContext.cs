using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestProgrammationConformit.Infrastructures
{
    public class ConformitContext : DbContext
    {
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }

        public ConformitContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evenement>(e =>
            {
                e.HasMany<Commentaire>(e => e.Commentaires)
                .WithOne(c => c.Evenement) ;
            });

            modelBuilder.Entity<Commentaire>(c =>
            {
                c.HasOne<Evenement>(c => c.Evenement)
                .WithMany(e => e.Commentaires)
                .HasForeignKey(c => c.EvenementId)
                .IsRequired(false);
            });

        }
    }
}
