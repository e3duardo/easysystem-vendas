
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class VendaParcela
    {
        public VendaParcela()
        {
        }

        public long Id { get; set; }
        public Library.Venda Venda { get; set; }
        public DateTime? Data { get; set; }
        public int? Pago { get; set; }
        public decimal? Valor { get; set; }
    }
    public class VendaParcelaBD
    {
        private VendaParcelaBD()
        {
        }

        static public void Save(Library.VendaParcela vendaParcela)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO VendaParcela (idVenda, data, pago, valor) VALUES (@idVenda, @data, @pago, @valor)"
                + "SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idVenda", vendaParcela.Venda.Id);
                comando.Parameters.AddWithValue("@data", vendaParcela.Data);
                comando.Parameters.AddWithValue("@pago", vendaParcela.Pago);
                comando.Parameters.AddWithValue("@valor", vendaParcela.Valor);

                conexao.Open();

                //comando.ExecuteNonQuery();
                vendaParcela.Id = (long)comando.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        static public void Update(Library.VendaParcela vendaParcela)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE VendaParcela SET idVenda = @idVenda, data = @data, pago = @pago, valor = @valor WHERE id= " + vendaParcela.Id;
                comando.Parameters.AddWithValue("@idVenda", vendaParcela.Venda.Id);
                comando.Parameters.AddWithValue("@data", vendaParcela.Data);
                comando.Parameters.AddWithValue("@pago", vendaParcela.Pago);
                comando.Parameters.AddWithValue("@valor", vendaParcela.Valor);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
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

                comando.CommandText = "DELETE FROM VendaParcela WHERE (idVenda= " + idVenda;

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
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

                comando.CommandText = "DELETE FROM VendaParcela WHERE (idVenda= " + venda.Id + ")";

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.VendaParcela> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM VendaParcela AS vp ";
                query += "INNER JOIN Venda AS v ON vp.idVenda = v.id ";

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
                        case "vp.id":
                            query += pre + "vp.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "vp.idVenda":
                            query += pre + "vp.idVenda = @idVenda";
                            comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
                            break;
                        case "vp.data":
                            query += pre + "vp.data = @data";
                            comando.Parameters.AddWithValue("@data", qi.Objeto);
                            break;
                        case "vp.pago":
                            query += pre + "vp.pago = @pago";
                            comando.Parameters.AddWithValue("@pago", qi.Objeto);
                            break;
                        case "vp.valor":
                            query += pre + "vp.valor = @valor";
                            comando.Parameters.AddWithValue("@valor", qi.Objeto);
                            break;
                        case "v.id":
                            query += pre + "v.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
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

                List<Library.VendaParcela> vendaParcelas = new List<Library.VendaParcela>();

                while (rdr.Read())
                {
                    Library.VendaParcela vendaParcela = new VendaParcela();
                    vendaParcela.Id = (long)rdr["id"];
                    vendaParcela.Venda = Library.VendaBD.FindVendaById((long)rdr["idVenda"]);
                    vendaParcela.Data = (DateTime)rdr["data"];
                    vendaParcela.Pago = (int)rdr["pago"];
                    vendaParcela.Valor = (decimal)rdr["valor"];

                    vendaParcelas.Add(vendaParcela);
                }

                return vendaParcelas;
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

        static public Library.VendaParcela FindVendaParcelaById(long id)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM VendaParcela WHERE id= " + id, conexao);

                ds = new DataSet();

                dap.Fill(ds, "VendaParcela");

                Library.VendaParcela vendaParcela = new VendaParcela();

                if (ds.Tables["VendaParcela"].Rows.Count == 1)
                {
                    vendaParcela.Id = (long)ds.Tables["VendaParcela"].Rows[0]["id"];
                    vendaParcela.Venda = Library.VendaBD.FindVendaById((long)ds.Tables["VendaParcela"].Rows[0]["idVenda"]);
                    vendaParcela.Data = (DateTime)ds.Tables["VendaParcela"].Rows[0]["data"];
                    vendaParcela.Pago = (int)ds.Tables["VendaParcela"].Rows[0]["pago"];
                    vendaParcela.Valor = (decimal)ds.Tables["VendaParcela"].Rows[0]["valor"];
                }

                return vendaParcela;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
                dap.Dispose();
                ds.Dispose();
            }
            return null;
        }
    }
}
