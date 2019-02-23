using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Venda
    {
        public Venda()
        {
        }

        public long Id { get; set; }
        public Library.Cliente Cliente { get; set; }
        public Library.Funcionario Funcionario { get; set; }
        public DateTime? Data { get; set; }
        public int? Pago { get; set; }
        public decimal Valor { get; set; }
        public string FormaPagamento { get; set; }

        public decimal Entrada { get; set; }
    }


    public class VendaBD
    {
        private VendaBD()
        {
        }

        static public void Save(Library.Venda venda)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Venda (idCliente, idFuncionario, data, pago, valor, formaPagamento, entrada) VALUES (@idCliente, @idFuncionario, @data, @pago, @valor, @formaPagamento, @entrada)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idCliente", venda.Cliente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", venda.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", venda.Data);
                comando.Parameters.AddWithValue("@pago", venda.Pago);
                comando.Parameters.AddWithValue("@valor", venda.Valor);
                comando.Parameters.AddWithValue("@formaPagamento", venda.FormaPagamento);
                comando.Parameters.AddWithValue("@entrada", venda.Entrada);

                conexao.Open();

                //comando.ExecuteNonQuery();
                venda.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Venda venda)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Venda SET idCliente = @idCliente, idFuncionario = @idFuncionario, data = @data, pago = @pago, valor = @valor, formaPagamento = @formaPagamento, entrada = @entrada WHERE (id= " + venda.Id + ")";
                comando.Parameters.AddWithValue("@idCliente", venda.Cliente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", venda.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", venda.Data);
                comando.Parameters.AddWithValue("@pago", venda.Pago);
                comando.Parameters.AddWithValue("@valor", venda.Valor);
                comando.Parameters.AddWithValue("@formaPagamento", venda.FormaPagamento);
                comando.Parameters.AddWithValue("@entrada", venda.Entrada);

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

        static public void Delete(Library.Venda venda)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Venda WHERE id='" + venda.Id + "'";

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

        static public List<Library.Venda> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Venda AS v ";
                query += "INNER JOIN Cliente AS c ON v.idCliente = c.id ";
                query += "INNER JOIN Funcionario AS f ON v.idFuncionario = f.id ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (qi.Campo != null)
                    {
                        if (p == 0)
                            pre = "WHERE ";
                        else
                            pre = " AND ";

                        p++;

                        switch (qi.Campo)
                        {
                            case "v.id":
                                query += pre + "(v.id = @id)";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "v.data varchar":
                                query += pre + "(CONVERT(varchar, v.data, 103) = '@data')";
                                comando.Parameters.AddWithValue("@data", qi.Objeto);
                                break;
                            case "v.formaPagamento":
                                query += pre + "(v.formaPagamento = @formaPagamento)";
                                comando.Parameters.AddWithValue("@formaPagamento", qi.Objeto);
                                break;
                            case "c.nome LIKE %%":
                                query += pre + "(c.nome LIKE '%' + @nome + '%')";
                                comando.Parameters.AddWithValue("@nome", qi.Objeto);
                                break;
                            case "c.id":
                                query += pre + "(c.id = @cid)";
                                comando.Parameters.AddWithValue("@cid", qi.Objeto);
                                break;


                            case "dataMaior":
                                //query += pre + "(CONVERT(varchar,v.data, 103) <= @dataMaior)";
                                query += pre + "(CONVERT(varchar,v.data, 23) <= @dataMaior)";
                                comando.Parameters.AddWithValue("@dataMaior", qi.Objeto);
                                break;
                            case "dataMenor":
                                //query += pre + "(CONVERT(varchar,v.data, 103) >= @dataMenor)";
                                query += pre + "(CONVERT(varchar,v.data, 23) >= @dataMenor)";
                                comando.Parameters.AddWithValue("@dataMenor", qi.Objeto);
                                break;

                            case "ORDER BY":
                                query += " ORDER BY " + qi.Objeto;
                                break;
                        }
                    }
                }
                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.Venda> vendas = new List<Library.Venda>();

                while (rdr.Read())
                {
                    Library.Venda venda = new Venda();
                    venda.Id = (long)rdr["id"];
                    venda.Cliente = Library.ClienteBD.FindById((long)rdr["idCliente"]);
                    venda.Funcionario = Library.FuncionarioBD.FindById((long)rdr["idFuncionario"]);
                    venda.Data = (DateTime)rdr["data"];
                    venda.Pago = (int)rdr["pago"];
                    venda.Valor = (decimal)rdr["valor"];
                    venda.FormaPagamento = rdr["formaPagamento"].ToString();
                    venda.Entrada = (decimal)rdr["entrada"];

                    vendas.Add(venda);
                }

                return vendas;
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

        static public Library.Venda FindVendaById(long idVenda)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Venda venda = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Venda WHERE id='" + idVenda + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Venda");

                if (ds.Tables["Venda"].Rows.Count == 1)
                {
                    //throw new ApplicationException("DataSet está vazio!");
                    venda = new Venda();
                    venda.Id = (long)ds.Tables["Venda"].Rows[0]["id"];
                    venda.Cliente = Library.ClienteBD.FindById((long)ds.Tables["Venda"].Rows[0]["idCliente"]);
                    venda.Funcionario = Library.FuncionarioBD.FindById((long)ds.Tables["Venda"].Rows[0]["idFuncionario"]);
                    venda.Data = (DateTime)ds.Tables["Venda"].Rows[0]["data"];
                    venda.Pago = (int)ds.Tables["Venda"].Rows[0]["pago"];
                    venda.Valor = (decimal)ds.Tables["Venda"].Rows[0]["valor"];
                    venda.FormaPagamento = ds.Tables["Venda"].Rows[0]["formaPagamento"].ToString();
                    venda.Entrada = (decimal)ds.Tables["Venda"].Rows[0]["entrada"];
                }
                return venda;
            }
            catch (SqlException ex)
            {
                //faça algoC
                Library.Diagnostics.Logger.Error(ex); ;
            }
            catch (Exception ex)
            {
                //faça algo
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

                comando.CommandText = "SELECT IDENT_CURRENT('Venda') AS lastId";

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
