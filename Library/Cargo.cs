using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Cargo
    {
        public Cargo()
        {
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
    public class CargoBD
    {
        private CargoBD()
        {
        }

        static public void Save(Library.Cargo cargo)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Cargo (nome, descricao, dataCadastro) VALUES (@nome, @descricao, @dataCadastro)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@nome", cargo.Nome);
                comando.Parameters.AddWithValue("@descricao", cargo.Descricao);
                comando.Parameters.AddWithValue("@dataCadastro", cargo.DataCadastro);

                conexao.Open();

                //comando.ExecuteNonQuery();
                cargo.Id = (long)comando.ExecuteScalar();

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

        static public void Update(Library.Cargo cargo)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Cargo SET nome = @nome, descricao = @descricao, dataCadastro = @dataCadastro WHERE (id= " + cargo.Id + ")";
                comando.Parameters.AddWithValue("@nome", cargo.Nome);
                comando.Parameters.AddWithValue("@descricao", cargo.Descricao);
                comando.Parameters.AddWithValue("@dataCadastro", cargo.DataCadastro);

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

        static public void DeleteById(long idCargo)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Cargo WHERE id='" + idCargo + "'";

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

        static public List<Library.Cargo> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Cargo AS cg ";

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
                        case "cg.id":
                            query += pre + "(cg.id = @id)";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "cg.nome":
                            query += pre + "(cg.nome = @nome)";
                            comando.Parameters.AddWithValue("@nome", qi.Objeto);
                            break;
                        case "cg.descricao":
                            query += pre + "(cg.descricao = @descricao)";
                            comando.Parameters.AddWithValue("@descricao", qi.Objeto);
                            break;
                        case "cg.dataCadastro":
                            query += pre + "(cg.dataCadastro = @dataCadastro)";
                            comando.Parameters.AddWithValue("@dataCadastro", qi.Objeto);
                            break;
                        case "cg.nome LIKE %%":
                            query += pre + "(cg.nome LIKE '%' + @nome + '%')";
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

                List<Library.Cargo> cargos = new List<Library.Cargo>();

                while (rdr.Read())
                {
                    Library.Cargo cargo = new Cargo();
                    cargo.Id = (long)rdr["id"];
                    cargo.Nome = rdr["nome"].ToString();
                    cargo.Descricao = rdr["descricao"].ToString();
                    cargo.DataCadastro = (DateTime)rdr["dataCadastro"];

                    cargos.Add(cargo);
                }

                return cargos;
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

        static public Library.Cargo FindById(long idCargo)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Cargo cargo = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Cargo WHERE id='" + idCargo + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Cargo");

                if (ds.Tables["Cargo"].Rows.Count == 1)
                {
                    cargo = new Cargo();
                    cargo.Id = (long)ds.Tables["Cargo"].Rows[0]["id"];
                    cargo.Nome = ds.Tables["Cargo"].Rows[0]["nome"].ToString();
                    cargo.Descricao = ds.Tables["Cargo"].Rows[0]["descricao"].ToString();
                    cargo.DataCadastro = (DateTime)ds.Tables["Cargo"].Rows[0]["dataCadastro"];
                }
                return cargo;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Cargo') AS lastId";

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
