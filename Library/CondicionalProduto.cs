using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library
{
    public class CondicionalProduto
    {
        public CondicionalProduto()
        {
        }


        public Library.Condicional Orcamento { get; set; }
        public Library.Produto Produto { get; set; }
        public decimal? Preco { get; set; }
        public decimal? PrecoTotal { get; set; }
        public double? Quantidade { get; set; }
    }
    public class CondicionalProdutoBD
    {
        private CondicionalProdutoBD()
        {
        }

        static public void Save(Library.CondicionalProduto orcamentoProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO OrcamentoProduto (idOrcamento, idProduto, preco, precoTotal, quantidade) VALUES (@idOrcamento, @idProduto, @preco, @precoTotal, @quantidade)";

                comando.Parameters.AddWithValue("@idOrcamento", orcamentoProduto.Orcamento.Id);
                comando.Parameters.AddWithValue("@idProduto", orcamentoProduto.Produto.Id);
                comando.Parameters.AddWithValue("@preco", orcamentoProduto.Preco);
                comando.Parameters.AddWithValue("@precoTotal", orcamentoProduto.PrecoTotal);
                comando.Parameters.AddWithValue("@quantidade", orcamentoProduto.Quantidade);

                conexao.Open();

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void Update(Library.CondicionalProduto orcamentoProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE OrcamentoProduto SET idOrcamento = @idOrcamento, idProduto = @idProduto, preco = @preco, precoTotal = @precoTotal, quantidade = @quantidade WHERE (idOrcamento= @WidOrcamento AND idProduto = @WidProduto)";
                comando.Parameters.AddWithValue("@idOrcamento", orcamentoProduto.Orcamento.Id);
                comando.Parameters.AddWithValue("@idProduto", orcamentoProduto.Produto.Id);
                comando.Parameters.AddWithValue("@preco", orcamentoProduto.Preco);
                comando.Parameters.AddWithValue("@precoTotal", orcamentoProduto.PrecoTotal);
                comando.Parameters.AddWithValue("@quantidade", orcamentoProduto.Quantidade);

                comando.Parameters.AddWithValue("@WidOrcamento", orcamentoProduto.Orcamento.Id);
                comando.Parameters.AddWithValue("@WidProduto", orcamentoProduto.Produto.Id);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void DeleteById(long idOrcamento, long idProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM OrcamentoProduto WHERE (idOrcamento= @WidOrcamento AND idProduto = @WidProduto)";

                comando.Parameters.AddWithValue("@WidOrcamento", idOrcamento);
                comando.Parameters.AddWithValue("@WidProduto", idProduto);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.CondicionalProduto> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM OrcamentoProduto AS opd ";
                query += "INNER JOIN Orcamento AS o ON opd.idOrcamento = o.id ";
                query += "INNER JOIN Produto AS p ON opd.idProduto = p.id ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (p == 0)
                        pre = "WHERE ";
                    else
                        pre = "AND ";

                    p++;

                    switch (qi.Campo)
                    {
                        case "opd.idOrcamento":
                            query += pre + "opd.idOrcamento = @idOrcamento";
                            comando.Parameters.AddWithValue("@idOrcamento", qi.Objeto);
                            break;
                        case "opd.idProduto":
                            query += pre + "opd.idProduto = @idProduto";
                            comando.Parameters.AddWithValue("@idProduto", qi.Objeto);
                            break;
                        case "opd.preco":
                            query += pre + "opd.preco = @preco";
                            comando.Parameters.AddWithValue("@preco", qi.Objeto);
                            break;
                        case "opd.precoTotal":
                            query += pre + "opd.precoTotal = @precoTotal";
                            comando.Parameters.AddWithValue("@precoTotal", qi.Objeto);
                            break;
                        case "opd.quantidade":
                            query += pre + "opd.quantidade = @quantidade";
                            comando.Parameters.AddWithValue("@quantidade", qi.Objeto);
                            break;
                        case "o.id":
                            query += pre + "o.id = @idOrcamento";
                            comando.Parameters.AddWithValue("@idOrcamento", qi.Objeto);
                            break;
                        case "ORDER BY":
                            query += " ORDER BY " + qi.Objeto;
                            break;
                    }
                }

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.CondicionalProduto> OrcamentoProdutos = new List<Library.CondicionalProduto>();

                while (rdr.Read())
                {
                    Library.CondicionalProduto orcamentoProduto = new CondicionalProduto();
                    orcamentoProduto.Orcamento = Library.CondicionalBD.FindOrcamentoById((long)rdr["idOrcamento"]);
                    orcamentoProduto.Produto = Library.ProdutoBD.FindById((long)rdr["idProduto"]);
                    orcamentoProduto.Preco = (decimal)rdr["preco"];
                    orcamentoProduto.PrecoTotal = (decimal)rdr["precoTotal"];
                    orcamentoProduto.Quantidade = (double)rdr["quantidade"];

                    OrcamentoProdutos.Add(orcamentoProduto);
                }

                return OrcamentoProdutos;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
            return null;
        }
    }
}
