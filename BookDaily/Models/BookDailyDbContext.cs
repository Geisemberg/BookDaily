using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookDaily.Models
{
    public partial class BookDailyDbContext : DbContext
    {
        public BookDailyDbContext()
        {
        }

        public BookDailyDbContext(DbContextOptions<BookDailyDbContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Aquí no se necesita especificar la cadena de conexión directamente
                // optionsBuilder.UseSqlServer("Server=datosdes.sistecredito.com; Database=BookDailyDB; User Id=Aplicacion; Password=##Apptest; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
