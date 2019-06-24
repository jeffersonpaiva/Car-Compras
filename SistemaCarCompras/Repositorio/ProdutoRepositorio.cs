using SistemaCarCompras.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaCarCompras.Repositorio
{
    public class ProdutoRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(constr);
        }


        public bool AdicionarProduto(Produto produtoObj)
        {
            Connection();

            int i;

            using (SqlCommand conn = new SqlCommand("InserirProduto", _con))
            {
                conn.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Parameters.AddWithValue("@Nome", produtoObj.Nome);
                conn.Parameters.AddWithValue("@Categoria", produtoObj.Categoria);
                conn.Parameters.AddWithValue("@Preco", produtoObj.Preco);
                conn.Parameters.AddWithValue("@CodBarras", produtoObj.CodBarras);

                _con.Open();

                i = conn.ExecuteNonQuery();

            }

            _con.Close();

            return i >= 1;
        }


        public List<Produto> ObterProdutos()
        {
            Connection();
            List<Produto> produtoList = new List<Produto>();

            using (SqlCommand command = new SqlCommand("SelecionarProduto", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                _con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Produto prod = new Produto()
                    {
                        ProdutoId = Convert.ToInt32(reader["ProdutoId"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Categoria = Convert.ToString(reader["Categoria"]),
                        Preco = Convert.ToDecimal(reader["Preco"]),
                        CodBarras = Convert.ToString(reader["CodBarras"])
                    };
                    produtoList.Add(prod);
                }
                _con.Close();
                return produtoList;
            }

        }


        public bool AtualizarProduto(Models.Produto produtoObj)
        {

            try
            {
                Connection();
                int i;
                using (SqlCommand command = new SqlCommand("AtualizarProduto", _con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Nome", produtoObj.Nome);
                    command.Parameters.AddWithValue("ProdutoId", produtoObj.ProdutoId);
                    command.Parameters.AddWithValue("Categoria", produtoObj.Categoria);
                    command.Parameters.AddWithValue("Preco", produtoObj.Preco);
                    command.Parameters.AddWithValue("CodBarras", produtoObj.CodBarras);


                    _con.Open();
                    i = command.ExecuteNonQuery();
                }
                _con.Close();
                return i >= 1;
            }
            catch (Exception e)
            {

                throw;
            }



        }


        public bool ExcluirProduto(int id)
        {
            try
            {
                Connection();
                int i;
                using (SqlCommand command = new SqlCommand("ExcluirProdutoPorId", _con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProdutoId", id);

                    _con.Open();
                    i = command.ExecuteNonQuery();
                }
                _con.Close();
                if (i >= 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Trava aqui");
                throw;
            }


        }
    }
}
