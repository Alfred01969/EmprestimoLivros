using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmprestimoLivros.Models
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }
        public string Autor { get; set; }

        [Column("Ano")]
        [Display(Name = "Ano Publicacao")]
        public string anoPublicacao { get; set; }

        [Column("Preco")]
        [Display(Name = "Preco")]
        public decimal Preco { get; set; }

       
        public bool emprestado { get; set; }

        //public bool gravarEmprestimo(int Id)
        //{
        //    emprestado = true;
        //    return emprestado;
        //}
    }
}
