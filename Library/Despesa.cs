using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Despesa
    {
        public Despesa()
        {
        }

        public long Id { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
    public class DespesaBD
    {
        private DespesaBD()
        {
        }

        static public void Save(Library.Despesa despesa)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Despesa (data, descricao, valor) VALUES (@data, @descricao, @valor)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@data", despesa.Data);
                comando.Parameters.AddWithValue("@descricao", despesa.Descricao);
                comando.Parameters.AddWithValue("@valor", despesa.Valor);

                conexao.Open();

                //comando.ExecuteNonQuery();
                despesa.Id = (long)comando.ExecuteScalar();

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

        static public bool Delete(Library.Despesa despesa)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Despesa WHERE id='" + despesa.Id + "'";

                conexao.Open();
                int teste = comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.Despesa> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Despesa AS d ";

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
                        case "d.id":
                            query += pre + "d.id = @id";
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

                List<Library.Despesa> despesas = new List<Library.Despesa>();

                while (rdr.Read())
                {
                    Library.Despesa despesa = new Despesa();
                    despesa.Id = (long)rdr["id"];
                    despesa.Data = (DateTime)rdr["data"];
                    despesa.Descricao = rdr["descricao"].ToString();
                    despesa.Valor = (decimal)rdr["valor"];

                    despesas.Add(despesa);
                }

                return despesas;
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

        static public Library.Despesa FindDespesaById(long idDespesa)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Despesa despesa = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Despesa WHERE id='" + idDespesa + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Despesa");

                if (ds.Tables["Despesa"].Rows.Count == 1)
                {
                    despesa = new Despesa();
                    despesa.Id = (long)ds.Tables["Despesa"].Rows[0]["id"];
                    despesa.Data = (DateTime)ds.Tables["Despesa"].Rows[0]["data"];
                    despesa.Descricao = ds.Tables["Despesa"].Rows[0]["descricao"].ToString();
                    despesa.Valor = (decimal)ds.Tables["Despesa"].Rows[0]["valor"];
                }
                return despesa;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Despesa') AS lastId";

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
