using Microsoft.EntityFrameworkCore.Migrations;

namespace ContatoAPI.Migrations
{
    public partial class Contato002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contatp",
                table: "Contato",
                newName: "ContatoName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContatoName",
                table: "Contato",
                newName: "Contatp");
        }
    }
}
