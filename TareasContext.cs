using Microsoft.EntityFrameworkCore;
using projectoef.Models;

namespace projectoef;

public class TareasContext: DbContext{
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Tarea> Tarea {get; set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion);
        });

        modelBuilder.Entity<Tarea>(tarea =>{
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(t => t.Categoria).WithMany(p => p.Tarea).HasForeignKey(p => p.CategoriaId);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Titulo);
            tarea.Property(t => t.Descripcion);
            tarea.Property(t => t.Titulo);
            tarea.Property(t => t.PrioridadTarea);
            tarea.Property(t => t.Fecha);
            tarea.Ignore(t => t.Resumen);
        });

    }
}