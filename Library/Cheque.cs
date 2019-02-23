using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Cheque
    {
        public Cheque()
        {
        }


        public long Id { get; set; }
        public Library.Venda Venda { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Numero { get; set; }
        public int Pago { get; set; }
    }
    public class ChequeBD
    {
        private ChequeBD()
        {
        }

        static public void Save(Library.Cheque cheque)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Cheque (data, valor, numero, pago, idVenda) VALUES (@data, @valor, @numero, @pago, @idVenda)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@data", cheque.Data);
                comando.Parameters.AddWithValue("@valor", cheque.Valor);
                comando.Parameters.AddWithValue("@numero", cheque.Numero);
                comando.Parameters.AddWithValue("@pago", cheque.Pago);

                if (cheque.Venda != null)
                    comando.Parameters.AddWithValue("@idVenda", cheque.Venda.Id);
                else
                    comando.Parameters.AddWithValue("@idVenda", DBNull.Value);



                conexao.Open();

                //comando.ExecuteNonQuery();
                cheque.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Cheque cheque)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "UPDATE Cheque SET data = @data, valor = @valor, numero = @numero, pago = @pago, idVenda = @idVenda WHERE (id= " + cheque.Id + ")";
                
                comando.Parameters.AddWithValue("@data", cheque.Data);
                comando.Parameters.AddWithValue("@valor", cheque.Valor);
                comando.Parameters.AddWithValue("@numero", cheque.Numero);
                comando.Parameters.AddWithValue("@pago", cheque.Pago);

                if (cheque.Venda != null)
                    comando.Parameters.AddWithValue("@idVenda", cheque.Venda.Id);
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

        static public void Delete(Library.Cheque cheque)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Cheque WHERE id='" + cheque.Id + "'";

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

        static public List<Library.Cheque> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Cheque AS cq " +
                               "LEFT JOIN Venda AS v ON cq.idVenda = v.id " +
                               "LEFT JOIN Servico AS s ON cq.idServico = s.id ";
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
                        case "cq.id":
                            query += pre + "cq.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "cq.data varchar":
                            query += pre + "CONVERT(varchar, cq.data, 103) = @data";
                            comando.Parameters.AddWithValue("@data", qi.Objeto);
                            break;
                        case "v.id":
                            query += pre + "v.id = @idVenda";
                            comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
                            break;
                        case "s.id":
                            query += pre + "s.id = @idServico";
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

                List<Library.Cheque> cheques = new List<Library.Cheque>();

                while (rdr.Read())
                {
                    Library.Cheque cheque = new Cheque();
                    cheque.Id = (long)rdr["id"];
                    cheque.Data = (DateTime)rdr["data"];
                    cheque.Valor = (decimal)rdr["valor"];
                    cheque.Numero = rdr["numero"].ToString();
                    cheque.Pago = (int)rdr["pago"];

                    if (!string.IsNullOrEmpty(rdr["idVenda"].ToString()))
                        cheque.Venda = Library.VendaBD.FindVendaById((long)rdr["idVenda"]);
                    else
                        cheque.Venda = null;

                    cheques.Add(cheque);
                }

                return cheques;
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

        static public Library.Cheque[] FindLimitAndOrderByDate()
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                dap = new SqlDataAdapter("SELECT MAX(id) AS id, pago FROM Cheque WHERE (pago = 0) GROUP BY data, pago", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Cheque");

                Library.Cheque[] ChequeArray = new Library.Cheque[ds.Tables["Cheque"].Rows.Count];

                for (int i = 0; i < ds.Tables["Cheque"].Rows.Count; i++)
                {
                    ChequeArray[i] = Library.ChequeBD.FindChequeById((long)ds.Tables["Cheque"].Rows[i]["id"]);
                }

                return ChequeArray;
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

        static public Library.Cheque FindChequeById(long idCheque)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Cheque cheque = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Cheque WHERE id=" + idCheque + "", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Cheque");

                if (ds.Tables["Cheque"].Rows.Count == 1)
                {
                    cheque = new Cheque();
                    cheque.Id = (long)ds.Tables["Cheque"].Rows[0]["id"];
                    cheque.Data = (DateTime)ds.Tables["Cheque"].Rows[0]["data"];
                    cheque.Valor = (decimal)ds.Tables["Cheque"].Rows[0]["valor"];
                    cheque.Numero = ds.Tables["Cheque"].Rows[0]["numero"].ToString();
                    cheque.Pago = (int)ds.Tables["Cheque"].Rows[0]["pago"];

                    if (!string.IsNullOrEmpty(ds.Tables["Cheque"].Rows[0]["idVenda"].ToString()))
                        cheque.Venda = Library.VendaBD.FindVendaById((long)ds.Tables["Cheque"].Rows[0]["idVenda"]);
                    else
                        cheque.Venda = null;
                }
                return cheque;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Cheque') AS lastId";

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
