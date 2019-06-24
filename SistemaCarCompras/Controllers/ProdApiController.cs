using SistemaCarCompras.Models;
using SistemaCarCompras.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace SistemaCarCompras.Controllers
{
    public class ProdApiController : ApiController
    {
        private ProdutoRepositorio _repositorio;

        [Route("api/ProdApi/GetDados")]
        public List<Produto> GetDados()
        {
            _repositorio = new ProdutoRepositorio();

            return _repositorio.ObterProdutos();
        }

        

    }
}
