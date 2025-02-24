using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTareas.Models
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        // ✅ Relación: Un Folder puede tener varias tareas
        public List<TodoTask> Tasks { get; set; } = new List<TodoTask>();
    }
}
