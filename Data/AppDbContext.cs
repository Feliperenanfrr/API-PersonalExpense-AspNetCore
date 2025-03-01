using API_PersonalExpense_AspNetCore.Model;
using Microsoft.EntityFrameworkCore;

namespace API_PersonalExpense_AspNetCore.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Gasto> Gastos { get; set; }
    public DbSet<MetaGasto> Metas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) :  base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Gasto>()
            .HasOne(g => g.Usuario)
            .WithMany(g => g.Gastos)
            .HasForeignKey(g => g.UsuarioId);

        modelBuilder.Entity<Gasto>()
            .HasOne(g => g.Categoria)
            .WithMany(g => g.Gastos)
            .HasForeignKey(g => g.CategoriaId);

        modelBuilder.Entity<MetaGasto>()
            .HasOne(m => m.Usuario)
            .WithMany(m => m.Metas)
            .HasForeignKey(g => g.UsuarioId);
    }
}