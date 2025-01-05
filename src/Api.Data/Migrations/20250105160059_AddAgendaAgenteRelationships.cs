using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddAgendaAgenteRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cliente_Descricao",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UserId",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AgendaAgenteId",
                table: "Cliente",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AgendaAgenteEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    AgenteId = table.Column<Guid>(nullable: false),
                    Dia = table.Column<DateTime>(nullable: false),
                    Cancelado = table.Column<bool>(nullable: false),
                    DataCancelamento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaAgenteEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaAgenteEntity_Agente_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_AgendaAgenteId",
                table: "Cliente",
                column: "AgendaAgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaAgenteEntity_AgenteId",
                table: "AgendaAgenteEntity",
                column: "AgenteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_AgendaAgenteEntity_AgendaAgenteId",
                table: "Cliente",
                column: "AgendaAgenteId",
                principalTable: "AgendaAgenteEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_AgendaAgenteEntity_AgendaAgenteId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "AgendaAgenteEntity");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_AgendaAgenteId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "AgendaAgenteId",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Cliente",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Descricao",
                table: "Cliente",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UserId",
                table: "Cliente",
                column: "UserId");
        }
    }
}
