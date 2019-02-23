using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Cartao
    {
        public Cartao()
        {
        }


        public long Id { get; set; }
        public Library.Venda Venda { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public int Parcelas { get; set; }
    }
    public class CartaoBD
    {
        private CartaoBD()
        {
        }

        static public void Save(Library.Cartao cartao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Cartao (data, valor, tipo, parcelas, idVenda) VALUES (@data, @valor, @tipo, @parcelas, @idVenda)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@data", cartao.Data);
                comando.Parameters.AddWithValue("@valor", cartao.Valor);
                comando.Parameters.AddWithValue("@tipo", cartao.Tipo);
                comando.Parameters.AddWithValue("@parcelas", cartao.Parcelas);

                if (cartao.Venda != null)
                    comando.Parameters.AddWithValue("@idVenda", cartao.Venda.Id);
                else
                    comando.Parameters.AddWithValue("@idVenda", DBNull.Value);



                conexao.Open();

                //comando.ExecuteNonQuery();
                cartao.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Cartao cartao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "UPDATE Cartao SET data = @data, valor = @valor, tipo = @tipo, parcelas = @parcelas, idVenda = @idVenda WHERE (id= " + cartao.Id + ")";
                
                comando.Parameters.AddWithValue("@data", cartao.Data);
                comando.Parameters.AddWithValue("@valor", cartao.Valor);
                comando.Parameters.AddWithValue("@tipo", cartao.Tipo);
                comando.Parameters.AddWithValue("@parcelas", cartao.Parcelas);

                if (cartao.Venda != null)
                    comando.Parameters.AddWithValue("@idVenda", cartao.Venda.Id);
                else
                    comando.Parameters.AddWithValue("@idVenda", DBNull.Value);

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

        static public void Delete(Library.Cartao cartao)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Cartao WHERE id='" + cartao.Id + "'";

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

        static public List<Library.Cartao> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Cartao AS ct " +
                               "LEFT JOIN Venda AS v ON ct.idVenda = v.id " +
                               "LEFT JOIN Servico AS s ON ct.idServico = s.id ";
                //"INNER JOIN Venda AS v ON cq.idVenda = v.id " +
                //"INNER JOIN Servico AS s ON cq.idServico = s.id ";

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
                        case "ct.id":
                            query += pre + "(ct.id = @id)";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "ct.data varchar":
                            query += pre + "(CONVERT(varchar, ct.data, 103) = @data)";
                            comando.Parameters.AddWithValue("@data", qi.Objeto);
                            break;
                        case "v.id":
                            query += pre + "(v.id = @idVenda)";
                            comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
                            break;
                        case "s.id":
                            query += pre + "(s.id = @idServico)";
                            comando.Parameters.AddWithValue("@idServico", qi.Objeto);
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

                List<Library.Cartao> cartoes = new List<Library.Cartao>();

                while (rdr.Read())
                {
                    Library.Cartao cartao = new Cartao();
                    cartao.Id = (long)rdr["id"];
                    cartao.Data = (DateTime)rdr["data"];
                    cartao.Valor = (decimal)rdr["valor"];
                    cartao.Tipo = rdr["tipo"].ToString();
                    cartao.Parcelas = (int)rdr["parcelas"];

                    if (!string.IsNullOrEmpty(rdr["idVenda"].ToString()))
                        cartao.Venda = Library.VendaBD.FindVendaById((long)rdr["idVenda"]);
                    else
                        cartao.Venda = null;

                    cartoes.Add(cartao);
                }

                return cartoes;
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

        static public List<DateTime> FindAdvancedDistinctDate()
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT DISTINCT data FROM Cartao ";
               
                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<DateTime> datas = new List<DateTime>();

                while (rdr.Read())
                {
                    datas.Add((DateTime)rdr["data"]);
                }

                return datas;
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

        static public Library.Cartao FindCartaoById(long idCartao)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Cartao cartao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Cartao WHERE id=" + idCartao + "", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Cartao");

                if (ds.Tables["Cartao"].Rows.Count == 1)
                {
                    cartao = new Cartao();
                    cartao.Id = (long)ds.Tables["Cartao"].Rows[0]["id"];
                    cartao.Data = (DateTime)ds.Tables["Cartao"].Rows[0]["data"];
                    cartao.Valor = (decimal)ds.Tables["Cartao"].Rows[0]["valor"];
                    cartao.Tipo = ds.Tables["Cartao"].Rows[0]["tipo"].ToString();
                    cartao.Parcelas = (int)ds.Tables["Cartao"].Rows[0]["parcelas"];

                    if (!string.IsNullOrEmpty(ds.Tables["Cartao"].Rows[0]["idVenda"].ToString()))
                        cartao.Venda = Library.VendaBD.FindVendaById((long)ds.Tables["Cartao"].Rows[0]["idVenda"]);
                    else
                        cartao.Venda = null;
                }
                return cartao;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Cartao') AS lastId";

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

    }
}
