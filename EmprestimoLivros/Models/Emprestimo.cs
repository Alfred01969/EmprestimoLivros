using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmprestimoLivros.Models
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

        [Display(Name = "Data de Empréstimo")]
        public DateTime DtEmpretimo { get; set; }

        [Display(Name = "Data de Devolução")]
        public DateTime? DtDevolucao { get; set; }

        [Display(Name = "Escolha o Livro")]
        public int LivroId { get; set; }

        public Livro? Livro { get; set; }

        [Display(Name = "Escolha o Cliente")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
