using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeFuncionarios.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }
        [Display(Name = "Função")] // Define como será exibido
        public string Funcao { get; set; }

        [Display(Name = "Salário")]
        [Range(0, double.MaxValue, ErrorMessage = "O salário deve ser um número  positivo.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Salario { get; set; }
    }
}