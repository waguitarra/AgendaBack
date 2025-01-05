using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RenameAgendaAgenteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Renomeia a tabela de "agendaagenteentity" para "AgendaAgente"
            migrationBuilder.RenameTable(
                name: "agendaagenteentity", // Nome atual da tabela no banco
                newName: "AgendaAgente"   // Novo nome da tabela
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Desfaz a renomeação, voltando para "agendaagenteentity"
            migrationBuilder.RenameTable(
                name: "AgendaAgente",       // Novo nome da tabela
                newName: "agendaagenteentity" // Nome antigo da tabela
            );
        }
    }
}
