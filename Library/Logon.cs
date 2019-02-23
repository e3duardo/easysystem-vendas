using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    public class Logon
    {
        public Logon()
        {
        }


        public long Id { get; set; }
        public Library.Funcionario Funcionario { get; set; }
        public DateTime? Data { get; set; }
    }
    public class LogonBD
    {
        private LogonBD()
        {
        }

        static public void Save(Library.Logon logons)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Logon (idFuncionario, data) VALUES (@idFuncionario, @data)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idFuncionario", logons.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", logons.Data);

                conexao.Open();

                //comando.ExecuteNonQuery();
                logons.Id = (long)comando.ExecuteScalar();

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

        static public void Update(Library.Logon logons)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Logon SET idFuncionario = @idFuncionario, data = @data WHERE (id= " + logons.Id + ")";
                comando.Parameters.AddWithValue("@idFuncionario", logons.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", logons.Data);

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

        static public void DeleteById(long idLogon)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Logon WHERE id='" + idLogon + "'";

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

        static public void DeleteAll()
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Logon";

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

        static public List<Library.Logon> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Logon AS l ";

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
                        case "l.id":
                            query += pre + "l.id = @id";
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

                List<Library.Logon> logonsList = new List<Library.Logon>();

                while (rdr.Read())
                {
                    Library.Logon logons = new Logon();
                    logons.Id = (long)rdr["id"];
                    logons.Funcionario = Library.FuncionarioBD.FindById((long)rdr["idFuncionario"]);
                    logons.Data = (DateTime)rdr["data"];

                    logonsList.Add(logons);
                }

                return logonsList;
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

        static public Library.Logon FindLogonById(long idLogon)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Logon logons = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Logon WHERE id='" + idLogon + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Logon");

                if (ds.Tables["Logon"].Rows.Count == 1)
                {
                    logons = new Logon();
                    logons.Id = (long)ds.Tables["Logon"].Rows[0]["id"];
                    logons.Funcionario = Library.FuncionarioBD.FindById((long)ds.Tables["Logon"].Rows[0]["idFuncionario"]);
                    logons.Data = (DateTime)ds.Tables["Logon"].Rows[0]["data"];
                }
                return logons;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Logon') AS lastId";

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
