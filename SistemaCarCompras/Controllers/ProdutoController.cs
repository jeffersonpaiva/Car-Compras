using SistemaCarCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCarCompras.Repositorio;




namespace SistemaCarCompras.Controllers
{
    public class ProdutoController : Controller
    {

        private ProdutoRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterProdutos()
        {
            _repositorio = new ProdutoRepositorio();
            ModelState.Clear();
            return View(_repositorio.ObterProdutos());
        }



        [HttpGet]
        public ActionResult IncluirProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirProduto(Produto produtoObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new ProdutoRepositorio();

                    if (_repositorio.AdicionarProduto(produtoObj))
                    {
                        ViewBag.Mensagem = "Produto cadastrado com sucesso";
                    }
                }
                return RedirectToAction("ObterProdutos");
            }
            catch (Exception)
            {
                return View("ObterProdutos");
            }
        }


        [HttpGet]
        public ActionResult EditarProduto(int id)
        {
            _repositorio = new ProdutoRepositorio();

            return View(_repositorio.ObterProdutos().Find(x => x.ProdutoId == id));
        }

        [HttpPost]
        public ActionResult EditarProduto(int id, Produto produtoObj)
        {
            try
            {
                _repositorio = new ProdutoRepositorio();
                _repositorio.AtualizarProduto(produtoObj);

                return RedirectToAction("ObterProdutos");
            }
            catch (Exception)
            {
                return View("ObterProdutos");
            }
        }

        public ActionResult ExcluirProduto(int id)
        {
            try
            {
                _repositorio = new ProdutoRepositorio();
                if (_repositorio.ExcluirProduto(id))
                {
                    ViewBag.Mensagem = "Produto excluido com sucesso";
                }

                return RedirectToAction("ObterProdutos");
            }
            catch (Exception)
            {
                return View("ObterProdutos");
                throw;
            }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}

