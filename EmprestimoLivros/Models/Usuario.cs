using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string UsuarioNome { get; set; }
        public string Login { get; set; }

        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        //public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualização { get; set; }
    }
}
