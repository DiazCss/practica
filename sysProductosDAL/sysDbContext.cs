using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sysProductoEN;
namespace sysProductosDAL
{
    public class sysDbContext : DbContext
    {

        public sysDbContext(DbContextOptions<sysDbContext> options) : base(options) { }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Categoria> categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>()
               .HasOne(p => p.categoria)
               .WithMany(c => c.Productos) 
               .HasForeignKey(p => p.CategoriaId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
