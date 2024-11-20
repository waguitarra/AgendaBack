using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AgenteId",
                table: "Cliente",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Cliente",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "json",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgenteId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "json",
                table: "Cliente");
        }
    }
}
