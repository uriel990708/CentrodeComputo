using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;
using GestorTareas.Models; // Reemplaza YourProjectName con el nombre de tu proyecto

namespace GestorTareas.Data // Reemplaza YourProjectName con el nombre de tu proyecto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Renombrar la propiedad Tasks a TodoTasks para evitar ambigüedad
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed user data
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