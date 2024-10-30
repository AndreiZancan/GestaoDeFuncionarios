using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestaoDeFuncionarios;
using GestaoDeFuncionarios.Context;
using GestaoDeFuncionarios.Models;

namespace GestaodeFuncionarios.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly GestaoFuncionariosContext _context;

        public FuncionarioController(GestaoFuncionariosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return View(funcionarios);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Editar(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Editar(Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(funcionario.Id);
            if (funcionarioBanco == null)
            { return RedirectToAction(nameof(Index)); }



            funcionarioBanco.Nome = funcionario.Nome;
            funcionarioBanco.Telefone = funcionario.Telefone;
            funcionarioBanco.Funcao = funcionario.Funcao;
            funcionarioBanco.Salario = funcionario.Salario;

            _context.Funcionarios.Update(funcionarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Detalhes(int Id)
        {
            var funcionario = _context.Funcionarios.Find(Id);
            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);

        }


        [HttpGet]
        public IActionResult Deletar(int Id)
        {
            var funcionario = _context.Funcionarios.Find(Id);

            if (funcionario == null)
                return RedirectToAction(nameof(Index));

            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Deletar(Funcionario funcionario)
        {
            var funcionarioBanco = _context.Funcionarios.Find(funcionario.Id);
            _context.Funcionarios.Remove(funcionarioBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}