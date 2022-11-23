using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jac.Tripulantes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateLocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tripulantes_CategoriaId",
                table: "Tripulantes",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tripulantes_Categorias_CategoriaId",
                table: "Tripulantes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tripulantes_Categorias_CategoriaId",
                table: "Tripulantes");

            migrationBuilder.DropIndex(
                name: "IX_Tripulantes_CategoriaId",
                table: "Tripulantes");
        }
    }
}
