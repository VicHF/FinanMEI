using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinanMEI.Models
{
    [Table("tb_vendas")]
    public class Venda
    {
        [Key]
        [Column("ID_Venda")]
        public int IdVenda { get; set; }

        [Required]
        [ForeignKey("Produto")]
        [Column("ID_Produto")]
        public int IdProduto { get; set; }
        public Produto? Produto { get; set; }

        [Required]
        [Column("Nome_Produto", TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        [DisplayName("Produto")]
        public string NomeProduto { get; set; }

        [Required]
        [Column("Valor_Unitario", TypeName = "DECIMAL(18, 2)")]
        [DisplayName("Valor Unitário")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ValorUnitario { get; set; }

        [Required]
        [DisplayName("Quantidade")]
        public int Qtde {  get; set; }

        [Column("Data", TypeName = "DATETIME")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
