using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanMEI.Migrations
{
    /// <inheritdoc />
    public partial class tabelaDespesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_despesa",
                columns: table => new
                {
                    ID_Despesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao_Despesa = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_despesa", x => x.ID_Despesa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_despesa");
        }
    }
}
