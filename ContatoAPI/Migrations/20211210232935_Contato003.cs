using Microsoft.EntityFrameworkCore.Migrations;

namespace ContatoAPI.Migrations
{
    public partial class Contato003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContatoName",
                table: "Contato",
                newName: "NumeroContato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroContato",
                table: "Contato",
                newName: "ContatoName");
        }
    }
}
