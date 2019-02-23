using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    public class Condicional
    {
        public Condicional()
        {
        }

        public long Id { get; set; }
        public Library.Cliente Cliente { get; set; }
        public Library.Funcionario Funcionario { get; set; }
        public DateTime? Data { get; set; }
        public decimal Valor { get; set; }
    }

    public class CondicionalBD
    {
        private CondicionalBD()
        {
        }

        static public void Save(Library.Condicional orcamento)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Orcamento (idCliente, idFuncionario, data, valor) VALUES (@idCliente, @idFuncionario, @data, @valor)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idCliente", orcamento.Cliente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", orcamento.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", orcamento.Data);
                comando.Parameters.AddWithValue("@valor", orcamento.Valor);

                conexao.Open();

                //comando.ExecuteNonQuery();
                orcamento.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Condicional orcamento)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Orcamento SET idCliente = @idCliente, idFuncionario = @idFuncionario, data = @data, valor = @valor WHERE (id= " + orcamento.Id + ")";
                comando.Parameters.AddWithValue("@idCliente", orcamento.Cliente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", orcamento.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", orcamento.Data);
                comando.Parameters.AddWithValue("@valor", orcamento.Valor);

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

        static public void DeleteById(long idOrcamento)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Orcamento WHERE id='" + idOrcamento + "'";

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

        static public List<Library.Condicional> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Orcamento AS o ";
                query += "INNER JOIN Cliente AS c ON o.idCliente = c.id ";
                query += "INNER JOIN Funcionario AS f ON o.idFuncionario = f.id ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (qi.Campo != null)
                    {
                        if (p == 0)
                            pre = "WHERE ";
                        else
                            pre = "AND ";

                        p++;

                        switch (qi.Campo)
                        {
                            case "o.id":
                                query += pre + "o.id = @id";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "o.data varchar":
                                query += pre + "(CONVERT(varchar, o.data, 103) = '@data')";
                                comando.Parameters.AddWithValue("@data", qi.Objeto);
                                break;
                            case "o.formaPagamento":
                                query += pre + "(o.formaPagamento = @formaPagamento)";
                                comando.Parameters.AddWithValue("@formaPagamento", qi.Objeto);
                                break;
                            case "c.nome LIKE %%":
                                query += pre + "(c.nome LIKE '%' + @nome + '%')";
                                comando.Parameters.AddWithValue("@nome", qi.Objeto);
                                break;


                            case "dataMaior":
                                query += pre + "(CONVERT(varchar,o.data, 23) <= @dataMaior)";
                                comando.Parameters.AddWithValue("@dataMaior", qi.Objeto);
                                break;
                            case "dataMenor":
                                query += pre + "(CONVERT(varchar,o.data, 23) >= @dataMenor)";
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

                List<Library.Condicional> orcamentos = new List<Library.Condicional>();

                while (rdr.Read())
                {
                    Library.Condicional orcamento = new Condicional();
                    orcamento.Id = (long)rdr["id"];
                    orcamento.Cliente = Library.ClienteBD.FindById((long)rdr["idCliente"]);
                    orcamento.Funcionario = Library.FuncionarioBD.FindById((long)rdr["idFuncionario"]);
                    orcamento.Data = (DateTime)rdr["data"];
                    orcamento.Valor = (decimal)rdr["valor"];

                    orcamentos.Add(orcamento);
                }

                return orcamentos;
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

        static public Library.Condicional FindOrcamentoById(long idOrcamento)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Condicional orcamento = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Orcamento WHERE id='" + idOrcamento + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Orcamento");

                if (ds.Tables["Orcamento"].Rows.Count == 1)
                {
                    orcamento = new Condicional();
                    orcamento.Id = (long)ds.Tables["Orcamento"].Rows[0]["id"];
                    orcamento.Cliente = Library.ClienteBD.FindById((long)ds.Tables["Orcamento"].Rows[0]["idCliente"]);
                    orcamento.Funcionario = Library.FuncionarioBD.FindById((long)ds.Tables["Orcamento"].Rows[0]["idFuncionario"]);
                    orcamento.Data = (DateTime)ds.Tables["Orcamento"].Rows[0]["data"];
                    orcamento.Valor = (decimal)ds.Tables["Orcamento"].Rows[0]["valor"];
                }
                return orcamento;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Orcamento') AS lastId";

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
