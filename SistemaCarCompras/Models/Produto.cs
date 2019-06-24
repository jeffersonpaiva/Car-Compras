using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCarCompras.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }


        public string Nome { get; set; }

        public string Categoria { get; set; }

        public decimal Preco { get; set; }

        public string CodBarras { get; set; }
    }
}