using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;


namespace GestaoDeFuncionarios.Context
{
    public class GestaoFuncionariosContext : DbContext
    {
        public GestaoFuncionariosContext(DbContextOptions<GestaoFuncionariosContext> options) : base(options)
        {
            
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}