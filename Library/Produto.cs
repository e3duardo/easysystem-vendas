using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    public class Produto
    {
        public Produto()
        {
        }

        public long Id { get; set; }
        public Library.Setor Setor { get; set; }
        public Library.Fornecedor Fornecedor { get; set; }
        public string CodigoBarra { get; set; }
        public double Estoque { get; set; }
        public double EstoqueRisco { get; set; }

        public double Vendido { get; set; }

        public string Nome { get; set; }

        public decimal PrecoCusto { get; set; }
        public int Imposto { get; set; }
        public int Lucro { get; set; }
        public decimal PrecoVenda { get; set; }
        public int DescontoAVista { get; set; }
        public decimal PrecoVendaAVista { get; set; }
        
        public DateTime DataCadastro { get; set; }
    }

    public class ProdutoBD
    {
        private ProdutoBD()
        {
        }

        static public void Save(Library.Produto produto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Produto (idSetor, idFornecedor, codigoBarra, estoque, estoqueRisco, imposto, lucro, nome, precoCusto, precoVenda, precoVenda2, vendido, dataCadastro, descontoAVista) VALUES (@idSetor, @idFornecedor, @codigoBarra, @estoque, @estoqueRisco, @imposto, @lucro, @nome, @precoCusto, @precoVenda, @precoVenda2, @vendido, @dataCadastro, @descontoAVista)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idSetor", produto.Setor.Id);
                comando.Parameters.AddWithValue("@idFornecedor", produto.Fornecedor.Id);
                comando.Parameters.AddWithValue("@codigoBarra", produto.CodigoBarra);
                comando.Parameters.AddWithValue("@estoque", produto.Estoque);
                comando.Parameters.AddWithValue("@estoqueRisco", produto.EstoqueRisco);
                comando.Parameters.AddWithValue("@imposto", produto.Imposto);
                comando.Parameters.AddWithValue("@lucro", produto.Lucro);
                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@precoCusto", produto.PrecoCusto);
                comando.Parameters.AddWithValue("@precoVenda", produto.PrecoVenda);
                comando.Parameters.AddWithValue("@precoVenda2", produto.PrecoVendaAVista);
                comando.Parameters.AddWithValue("@vendido", produto.Vendido);
                comando.Parameters.AddWithValue("@descontoAVista", produto.DescontoAVista);
                
                comando.Parameters.AddWithValue("@dataCadastro", produto.DataCadastro);

                conexao.Open();

                //comando.ExecuteNonQuery();
                produto.Id = (long)comando.ExecuteScalar();

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

        static public void Update(Library.Produto produto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Produto SET idSetor = @idSetor, idFornecedor = @idFornecedor, codigoBarra = @codigoBarra, estoque = @estoque, estoqueRisco = @estoqueRisco, imposto = @imposto, lucro = @lucro, nome = @nome, precoCusto = @precoCusto, precoVenda = @precoVenda, precoVenda2 = @precoVenda2, vendido = @vendido, dataCadastro = @dataCadastro, descontoAVista = @descontoAVista WHERE (id= " + produto.Id + ")";
                comando.Parameters.AddWithValue("@idSetor", produto.Setor.Id);
                comando.Parameters.AddWithValue("@idFornecedor", produto.Fornecedor.Id);
                comando.Parameters.AddWithValue("@codigoBarra", produto.CodigoBarra);
                comando.Parameters.AddWithValue("@estoque", produto.Estoque);
                comando.Parameters.AddWithValue("@estoqueRisco", produto.EstoqueRisco);
                comando.Parameters.AddWithValue("@imposto", produto.Imposto);
                comando.Parameters.AddWithValue("@lucro", produto.Lucro);
                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@precoCusto", produto.PrecoCusto);
                comando.Parameters.AddWithValue("@precoVenda", produto.PrecoVenda);
                comando.Parameters.AddWithValue("@precoVenda2", produto.PrecoVendaAVista);
                comando.Parameters.AddWithValue("@vendido", produto.Vendido);
                comando.Parameters.AddWithValue("@dataCadastro", produto.DataCadastro);

                comando.Parameters.AddWithValue("@descontoAVista", produto.DescontoAVista);

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

        static public void DeleteById(long idProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Produto WHERE id='" + idProduto + "'";

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

        static public List<Library.Produto> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Produto AS p ";

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
                        case "p.id":
                            query += pre + "(p.id = @id)";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "p.codigoBarra":
                            query += pre + "(p.codigoBarra = @codigoBarra)";
                            comando.Parameters.AddWithValue("@codigoBarra", qi.Objeto);
                            break;
                        case "p.nome LIKE %%":
                            query += pre + "(p.nome LIKE '%' + @nome + '%')";
                            comando.Parameters.AddWithValue("@nome", qi.Objeto);
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

                List<Library.Produto> produtos = new List<Library.Produto>();

                while (rdr.Read())
                {
                    Library.Produto produto = new Produto();
                    produto.Id = (long)rdr["id"];
                    produto.Setor = Library.SetorBD.FindById((long)rdr["idSetor"]);
                    produto.Fornecedor = Library.FornecedorBD.FindById((long)rdr["idFornecedor"]);
                    produto.CodigoBarra = rdr["codigoBarra"].ToString();
                    produto.Estoque = (double)rdr["estoque"];
                    produto.EstoqueRisco = (double)rdr["estoqueRisco"];
                    produto.Imposto = (int)rdr["imposto"];
                    produto.Lucro = (int)rdr["lucro"];
                    produto.Nome = rdr["nome"].ToString();
                    produto.PrecoCusto = (decimal)rdr["precoCusto"];
                    produto.PrecoVenda = (decimal)rdr["precoVenda"];
                    produto.PrecoVendaAVista = (decimal)rdr["precoVenda2"];
                    produto.Vendido = (double)rdr["vendido"];
                    produto.DataCadastro = (DateTime)rdr["dataCadastro"];
                    produto.DescontoAVista = (int)rdr["descontoAVista"];
                    

                    produtos.Add(produto);
                }

                return produtos;
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

        static public Library.Produto FindById(long idProduto)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Produto produto = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Produto WHERE id='" + idProduto + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Produto");

                if (ds.Tables["Produto"].Rows.Count == 1)
                {
                    produto = new Produto();
                    produto.Id = (long)ds.Tables["Produto"].Rows[0]["id"];
                    produto.Setor = Library.SetorBD.FindById((long)ds.Tables["Produto"].Rows[0]["idSetor"]);
                    produto.Fornecedor = Library.FornecedorBD.FindById((long)ds.Tables["Produto"].Rows[0]["idFornecedor"]);
                    produto.CodigoBarra = ds.Tables["Produto"].Rows[0]["codigoBarra"].ToString();
                    produto.Estoque = (double)ds.Tables["Produto"].Rows[0]["estoque"];
                    produto.EstoqueRisco = (double)ds.Tables["Produto"].Rows[0]["estoqueRisco"];
                    produto.Imposto = (int)ds.Tables["Produto"].Rows[0]["imposto"];
                    produto.Lucro = (int)ds.Tables["Produto"].Rows[0]["lucro"];
                    produto.Nome = ds.Tables["Produto"].Rows[0]["nome"].ToString();
                    produto.PrecoCusto = (decimal)ds.Tables["Produto"].Rows[0]["precoCusto"];
                    produto.PrecoVenda = (decimal)ds.Tables["Produto"].Rows[0]["precoVenda"];
                    produto.PrecoVendaAVista = (decimal)ds.Tables["Produto"].Rows[0]["precoVenda2"];
                    produto.Vendido = (double)ds.Tables["Produto"].Rows[0]["vendido"];
                    produto.DataCadastro = (DateTime)ds.Tables["Produto"].Rows[0]["dataCadastro"];
                    produto.DescontoAVista = (int)ds.Tables["Produto"].Rows[0]["descontoAVista"];

                    return produto;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
                dap.Dispose();
                ds.Dispose();
            }
            return null;
        }

        static public long GetNextId()
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "SELECT IDENT_CURRENT('Produto') AS lastId";

                conexao.Open();
                long lastId = 0;
                long.TryParse(comando.ExecuteScalar().ToString(), out lastId);


                return lastId + 1;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo">acabado,acabando,normal</param>
        /// <returns></returns>
        static public int GetCountByTipoEstoque(string tipo = "")
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                switch (tipo)
                {
                    case "acabado":
                        comando.CommandText = "SELECT COUNT(*) as ct FROM Produto WHERE (estoque <= 0)";
                        break;
                    case "acabando":
                        comando.CommandText = "SELECT COUNT(*) as ct FROM Produto WHERE (estoque <= estoqueRisco) AND (estoque > 0)";
                        break;
                    case "normal":
                        comando.CommandText = "SELECT COUNT(*) as ct FROM Produto WHERE (estoque > estoqueRisco)";
                        break;
                    default:
                        comando.CommandText = "SELECT COUNT(*) as ct FROM Produto";
                        break;
                }

                conexao.Open();
                int count = 0;
                int.TryParse(comando.ExecuteScalar().ToString(), out count);


                return count;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }
    }
}
