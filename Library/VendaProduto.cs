using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library
{
    public class VendaProduto
    {
        public VendaProduto()
        {
        }


        public Library.Venda Venda { get; set; }
        public Library.Produto Produto { get; set; }
        public decimal? Preco { get; set; }
        public decimal? PrecoTotal { get; set; }
        public double? Quantidade { get; set; }
    }
    public class VendaProdutoBD
    {
        private VendaProdutoBD()
        {
        }

        static public void Save(Library.VendaProduto vendaProduto)
        {
            //criando a conexao
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO VendaProduto (idVenda, idProduto, preco, precoTotal, quantidade) VALUES (@idVenda, @idProduto, @preco, @precoTotal, @quantidade)";

                comando.Parameters.AddWithValue("@idVenda", vendaProduto.Venda.Id);
                comando.Parameters.AddWithValue("@idProduto", vendaProduto.Produto.Id);
                comando.Parameters.AddWithValue("@preco", vendaProduto.Preco);
                comando.Parameters.AddWithValue("@precoTotal", vendaProduto.PrecoTotal);
                comando.Parameters.AddWithValue("@quantidade", vendaProduto.Quantidade);

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

        static public void Update(Library.VendaProduto vendaProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE VendaProduto SET idVenda = @idVenda, idProduto = @idProduto, preco = @preco, precoTotal = @precoTotal, quantidade = @quantidade WHERE (idVenda= @WidVenda AND idProduto = @WidProduto)";
                comando.Parameters.AddWithValue("@idVenda", vendaProduto.Venda.Id);
                comando.Parameters.AddWithValue("@idProduto", vendaProduto.Produto.Id);
                comando.Parameters.AddWithValue("@preco", vendaProduto.Preco);
                comando.Parameters.AddWithValue("@precoTotal", vendaProduto.PrecoTotal);
                comando.Parameters.AddWithValue("@quantidade", vendaProduto.Quantidade);

                comando.Parameters.AddWithValue("@WidVenda", vendaProduto.Venda.Id);
                comando.Parameters.AddWithValue("@WidProduto", vendaProduto.Produto.Id);

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

        static public void DeleteById(long idVenda, long idProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM VendaProduto WHERE (idVenda= @WidVenda AND idProduto = @WidProduto)";

                comando.Parameters.AddWithValue("@WidVenda", idVenda);
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

        static public void DeleteByVenda(Library.Venda venda)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM VendaProduto WHERE (idVenda= @WidVenda)";

                comando.Parameters.AddWithValue("@WidVenda", venda.Id);

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

        static public List<Library.VendaProduto> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM VendaProduto AS vp ";
                query += "INNER JOIN Venda AS v ON vp.idVenda = v.id ";
                query += "INNER JOIN Produto AS p ON vp.idProduto = p.id ";

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
                        case "vp.idVenda":
                            query += pre + "vp.idVenda = @idVenda";
                            comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
                            break;
                        case "vp.idProduto":
                            query += pre + "vp.idProduto = @idProduto";
                            comando.Parameters.AddWithValue("@idProduto", qi.Objeto);
                            break;
                        case "vp.preco":
                            query += pre + "vp.preco = @preco";
                            comando.Parameters.AddWithValue("@preco", qi.Objeto);
                            break;
                        case "vp.precoTotal":
                            query += pre + "vp.precoTotal = @precoTotal";
                            comando.Parameters.AddWithValue("@precoTotal", qi.Objeto);
                            break;
                        case "vp.quantidade":
                            query += pre + "vp.quantidade = @quantidade";
                            comando.Parameters.AddWithValue("@quantidade", qi.Objeto);
                            break;
                        case "v.id":
                            query += pre + "v.id = @idVenda";
                            comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
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

                List<Library.VendaProduto> vendaProdutos = new List<Library.VendaProduto>();

                while (rdr.Read())
                {
                    Library.VendaProduto vendaProduto = new VendaProduto();
                    vendaProduto.Venda = Library.VendaBD.FindVendaById((long)rdr["idVenda"]);
                    vendaProduto.Produto = Library.ProdutoBD.FindById((long)rdr["idProduto"]);
                    vendaProduto.Preco = (decimal)rdr["preco"];
                    vendaProduto.PrecoTotal = (decimal)rdr["precoTotal"];
                    vendaProduto.Quantidade = (double)rdr["quantidade"];

                    vendaProdutos.Add(vendaProduto);
                }

                return vendaProdutos;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
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
