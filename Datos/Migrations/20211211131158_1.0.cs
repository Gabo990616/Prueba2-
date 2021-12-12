using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Evento",
                table: "Evento");

            migrationBuilder.RenameTable(
                name: "Evento",
                newName: "Eventos");

            migrationBuilder.RenameColumn(
                name: "CantInscr",
                table: "Eventos",
                newName: "CantidadInscrita");

            migrationBuilder.RenameColumn(
                name: "AforoPerm",
                table: "Eventos",
                newName: "AforoPermitido");

            migrationBuilder.AddColumn<int>(
                name: "EventoCodigo",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EventoCodigo",
                table: "Usuarios",
                column: "EventoCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Eventos_EventoCodigo",
                table: "Usuarios",
                column: "EventoCodigo",
                principalTable: "Eventos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Eventos_EventoCodigo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EventoCodigo",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EventoCodigo",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "Evento");

            migrationBuilder.RenameColumn(
                name: "CantidadInscrita",
                table: "Evento",
                newName: "CantInscr");

            migrationBuilder.RenameColumn(
                name: "AforoPermitido",
                table: "Evento",
                newName: "AforoPerm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evento",
                table: "Evento",
                column: "Codigo");
        }
    }
}
