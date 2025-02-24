using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTareas.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }

        // Relación con Folder
        public int? FolderId { get; set; } // Puede ser nulo si la tarea no tiene carpeta
        public Folder? Folder { get; set; } // Propiedad de navegación
    }

}
