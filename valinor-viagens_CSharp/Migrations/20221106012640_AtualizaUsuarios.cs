using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace valinor_viagens_CSharp.Migrations
{
    public partial class AtualizaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuario");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "usuario",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "id_cliente",
                table: "usuario",
                newName: "id_cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Usuarios",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "id_cliente",
                table: "Usuarios",
                newName: "Id_cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }
    }
}
