using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddProdutosEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Produtos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Produtos");
        }
    }
}
