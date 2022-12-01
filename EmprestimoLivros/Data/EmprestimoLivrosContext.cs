using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmprestimoLivros.Models;

namespace EmprestimoLivros.Data
{
    public class EmprestimoLivrosContext : DbContext
    {
        public EmprestimoLivrosContext (DbContextOptions<EmprestimoLivrosContext> options)
            : base(options)
        {
        }

        public DbSet<EmprestimoLivros.Models.Livro> Livro { get; set; } = default!;

        public DbSet<EmprestimoLivros.Models.Cliente> Cliente { get; set; }

        public DbSet<EmprestimoLivros.Models.Emprestimo> Emprestimo { get; set; }
    }


}
