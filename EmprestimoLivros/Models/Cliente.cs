using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmprestimoLivros.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        public string Endereço { get; set; }

        public string Celular { get; set; }


        
    }
}
