using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanMEI.Migrations
{
    /// <inheritdoc />
    public partial class tabelaVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "tb_produto");

            migrationBuilder.RenameColumn(
                name: "NomeProduto",
                table: "tb_produto",
                newName: "Nome_Produto");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "tb_produto",
                newName: "ID_Produto");

            migrationBuilder.AlterColumn<string>(
                name: "Nome_Produto",
                table: "tb_produto",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor_Unitario",
                table: "tb_produto",
                type: "DECIMAL(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_produto",
                table: "tb_produto",
                column: "ID_Produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_produto",
                table: "tb_produto");

            migrationBuilder.DropColumn(
                name: "Valor_Unitario",
                table: "tb_produto");

            migrationBuilder.RenameTable(
                name: "tb_produto",
                newName: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Nome_Produto",
                table: "Produtos",
                newName: "NomeProduto");

            migrationBuilder.RenameColumn(
                name: "ID_Produto",
                table: "Produtos",
                newName: "IdProduto");

            migrationBuilder.AlterColumn<string>(
                name: "NomeProduto",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "IdProduto");
        }
    }
}
