using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCarCompras.Models;

namespace SistemaCarCompras.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Verificar(Usuario usu)
        {
            return View();
        }
    }
}