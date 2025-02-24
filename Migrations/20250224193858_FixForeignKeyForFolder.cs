using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace GestorTareas.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyForFolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Se han eliminado todas las operaciones porque las estructuras ya existen en la base de datos
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No hay operaciones que revertir
        }
    }
}