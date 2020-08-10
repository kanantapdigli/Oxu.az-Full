using Microsoft.EntityFrameworkCore;
using oxu.az.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oxu.az.Contexts
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions option)
            : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Siyasət" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "İqtisadiyyat" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Cəmiyyət" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Name = "Şou-Biznes" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 5, Name = "Müharibə" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 6, Name = "İdman" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 7, Name = "Kriminal" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 8, Name = "Mədəniyyət" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 9, Name = "Dünya" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 10, Name = "Avto-Moto" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 11, Name = "İKT" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 12, Name = "Turizm" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 13, Name = "Maraqlı" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 14, Name = "Müsahibə" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 15, Name = "Baku TV" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 16, Name = "Cinema Plus" });

            modelBuilder.Entity<Category>()
        .HasIndex(c => c.Name)
        .IsUnique();

        }


        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
