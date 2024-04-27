using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanMEI.Migrations
{
    /// <inheritdoc />
    public partial class tabelaVendas4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_vendas",
                columns: table => new
                {
                    ID_Venda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto = table.Column<int>(type: "int", nullable: false),
                    Nome_Produto = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Valor_Unitario = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendas", x => x.ID_Venda);
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_produto_ID_Produto",
                        column: x => x.ID_Produto,
                        principalTable: "tb_produto",
                        principalColumn: "ID_Produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_Nome_Produto",
                table: "tb_produto",
                column: "Nome_Produto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_ID_Produto",
                table: "tb_vendas",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_Nome_Produto_Data",
                table: "tb_vendas",
                columns: new[] { "Nome_Produto", "Data" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_vendas");

            migrationBuilder.DropIndex(
                name: "IX_tb_produto_Nome_Produto",
                table: "tb_produto");
        }
    }
}
