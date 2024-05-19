using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinanMEI.Models
{
    [Table("tb_produto")]
    public class Produto
    {
        
        [Key]
        [Column("ID_Produto")]
        public int IdProduto { get; set; }

        [Required]
        [Column("Nome_Produto", TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        [DisplayName("Produto")]
        public string NomeProduto { get; set; }

        [Required]
        [Column("Valor_Unitario", TypeName = "DECIMAL(18, 2)")]
        [DisplayName("Valor Unitário")]
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal ValorUnitario {  get; set; }

        public ICollection<Venda>? Vendas { get; set; }

    }
}
