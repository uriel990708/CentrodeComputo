using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorTareas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Folder> Folders { get; set; } // ✅ Nueva tabla para carpetas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Relación: Una carpeta puede tener muchas tareas
            modelBuilder.Entity<TodoTask>()
                .HasOne(t => t.Folder)
                .WithMany(f => f.Tasks)
                .HasForeignKey(t => t.FolderId)
                .OnDelete(DeleteBehavior.Cascade); // Si se borra una carpeta, sus tareas también se eliminan

            // ✅ Seed inicial de usuarios
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "jeanpiaget",
                    Password = "isc06mixto"
                }
            );
        }
    }
}
