using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaCarCompras.Models;
using System.Data.SqlClient;

namespace SistemaCarCompras.Controllers
{
    public class UsuariosController : Controller
    {
        SqlCommand con = new SqlCommand();
        private SqlConnection _con;
        SqlDataReader dr;
        // GET: Usuarios
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }




        public ActionResult Verificar(Usuario usu)
        {
            _con.Open();
            con.CommandText = "select * from Usuarios where usuario = '"+usu.Nome+"' and Senha = '"+usu.Senha+"'";
            dr = con.ExecuteReader();

            if (dr.Read())
            {
                _con.Close();
                return View();
            }
            else
            {
                _con.Close();
                return View();
            }

            
        }
    }
}