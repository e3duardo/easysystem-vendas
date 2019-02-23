using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Setor
    {
        public Setor()
        {
        }


        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCadastro { get; set; }

        public override string ToString()
        {
            return base.ToString() + "| ID: " + this.Id.ToString() + "| NOME: " + this.Nome;
        }
    }

    public class SetorBD
    {
        private SetorBD()
        {
        }

        static public void Save(Library.Setor setor)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Setor (nome, descricao, dataCadastro) VALUES (@nome, @descricao, @dataCadastro)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@nome", setor.Nome);
                comando.Parameters.AddWithValue("@descricao", setor.Descricao);
                comando.Parameters.AddWithValue("@dataCadastro", setor.DataCadastro);

                conexao.Open();

                //comando.ExecuteNonQuery();
                setor.Id = (long)comando.ExecuteScalar();

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

        static public void Update(Library.Setor setor)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "UPDATE Setor SET nome = @nome, descricao = @descricao, dataCadastro = @dataCadastro WHERE (id= " + setor.Id + ")";
                comando.Parameters.AddWithValue("@nome", setor.Nome);
                comando.Parameters.AddWithValue("@descricao", setor.Descricao);
                comando.Parameters.AddWithValue("@dataCadastro", setor.DataCadastro);

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

        static public void DeleteById(long idSetor)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Setor WHERE id='" + idSetor + "'";

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

        static public List<Library.Setor> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Setor AS s ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (p == 0)
                        pre = "WHERE ";
                    else
                        pre = " AND ";

                    p++;

                    switch (qi.Campo)
                    {
                        case "s.id":
                            query += pre + "(s.id = @id)";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "s.nome":
                            query += pre + "(s.nome = @nome)";
                            comando.Parameters.AddWithValue("@nome", qi.Objeto);
                            break;
                        case "s.descricao":
                            query += pre + "(s.descricao = @descricao)";
                            comando.Parameters.AddWithValue("@descricao", qi.Objeto);
                            break;
                        case "s.dataCadastro":
                            query += pre + "(s.dataCadastro = @dataCadastro)";
                            comando.Parameters.AddWithValue("@dataCadastro", qi.Objeto);
                            break;
                        case "s.nome LIKE %%":
                            query += pre + "(s.nome LIKE '%' + @nome + '%')";
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

                List<Library.Setor> setores = new List<Library.Setor>();
                
                while (rdr.Read())
                {
                    Library.Setor setor = new Setor();
                    setor.Id = (long)rdr["id"];
                    setor.Nome = rdr["nome"].ToString();
                    setor.Descricao = rdr["descricao"].ToString();
                    setor.DataCadastro = (DateTime)rdr["dataCadastro"];

                    setores.Add(setor);
                }

                return setores;
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

        static public Library.Setor FindById(long idSetor)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Setor setor = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Setor WHERE id='" + idSetor + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Setor");

                if (ds.Tables["Setor"].Rows.Count == 1)
                {
                    //throw new ApplicationException("DataSet está vazio!");
                    setor = new Setor();
                    setor.Id = (long)ds.Tables["Setor"].Rows[0]["id"];
                    setor.Nome = ds.Tables["Setor"].Rows[0]["nome"].ToString();
                    setor.Descricao = ds.Tables["Setor"].Rows[0]["descricao"].ToString();
                    setor.DataCadastro = (DateTime)ds.Tables["Setor"].Rows[0]["dataCadastro"];
                }
                return setor;
            }
            catch (SqlException ex)
            {
                Library.Diagnostics.Logger.Error(ex); ;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Setor') AS lastId";

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
