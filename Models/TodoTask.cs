namespace GestorTareas.Models // Reemplaza YourProjectName con el nombre de tu proyecto
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}