using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanMEI.Models
{
    [Table("tb_despesa")]
    public class Despesa
    {
        [Key]
        [Column("ID_Despesa")]
        public int IdDespesa { get; set; }

        [Required]
        [Column("Descricao_Despesa", TypeName = "NVARCHAR(100)")]
        [StringLength(100)]
        [DisplayName("Descrição da Despesa")]
        public string NomeDespesa { get; set; }

        [Required]
        [Column("Valor", TypeName = "DECIMAL")]
        [DisplayName("Valor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        //[DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Valor { get; set; }

        [Required]
        [Column("Categoria", TypeName = "NVARCHAR(50)")]
        [StringLength(50)]
        [DisplayName("Categoria")]
        public string Categoria { get; set; }

        [Column("Data", TypeName = "DATETIME")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
