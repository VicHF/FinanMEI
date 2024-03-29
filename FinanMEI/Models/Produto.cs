using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinanMEI.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        [Required]
        [DisplayName("Produto")]
        public string NomeProduto { get; set; }

        [Required]
        [DisplayName("Preço")]
        public double Preco {  get; set; }

    }
}
