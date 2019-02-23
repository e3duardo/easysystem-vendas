using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Library.Classes;

namespace Library
{
    public class Caixa
    {
        public Caixa()
        {
        }

        public long Id { get; set; }
        public DateTime? Data { get; set; }
        public decimal Saldo { get; set; }
        public string Status { get; set; }
    }

    public class CaixaBD
    {
        private CaixaBD()
        {
        }

        static public void Save(Library.Caixa caixa)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Caixa (data, saldo, status) VALUES (@data, @saldo, @status)"
                + "SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@data", caixa.Data);
                comando.Parameters.AddWithValue("@saldo", caixa.Saldo);
                comando.Parameters.AddWithValue("@status", caixa.Status);

                conexao.Open();

                //comando.ExecuteNonQuery();
                caixa.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Caixa caixa)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "UPDATE Caixa SET data = @data, saldo = @saldo, status = @status WHERE (id= " + caixa.Id + ")";
                comando.Parameters.AddWithValue("@data", caixa.Data);
                comando.Parameters.AddWithValue("@saldo", caixa.Saldo);
                comando.Parameters.AddWithValue("@status", caixa.Status);

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

        static public void DeleteById(long idCaixa)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Caixa WHERE id='" + idCaixa + "'";

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

        static public Library.Caixa FindCaixaById(long idCaixa)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;

            Library.Caixa Caixa = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Caixa WHERE id='" + idCaixa + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Caixa");

                if (ds.Tables["Caixa"].Rows.Count == 1)
                {
                    Caixa = new Caixa();
                    Caixa.Id = (long)ds.Tables["Caixa"].Rows[0]["id"];
                    Caixa.Data = (DateTime)ds.Tables["Caixa"].Rows[0]["Data"];
                    Caixa.Saldo = (decimal)ds.Tables["Caixa"].Rows[0]["Saldo"];
                    Caixa.Status = ds.Tables["Caixa"].Rows[0]["Status"].ToString();
                }
                return Caixa;
            }
            catch (SqlException ex)
            {
                Library.Diagnostics.Logger.Error(ex);
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

        static public List<Library.Caixa> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Caixa AS c ";

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
                        case "c.id":
                            query += pre + "c.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "c.data":
                            query += pre + "c.data = @data";
                            comando.Parameters.AddWithValue("@data", qi.Objeto);
                            break;
                        case "c.saldo":
                            query += pre + "c.saldo = @saldo";
                            comando.Parameters.AddWithValue("@saldo", qi.Objeto);
                            break;
                        case "c.status":
                            query += pre + "c.status = @status";
                            comando.Parameters.AddWithValue("@status", qi.Objeto);
                            break;
                        case "c.data varchar":
                            query += pre + "CONVERT(varchar, c.data, 103) = @dataVar";
                            comando.Parameters.AddWithValue("@dataVar", qi.Objeto);
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

                List<Library.Caixa> caixas = new List<Library.Caixa>();

                while (rdr.Read())
                {
                    Library.Caixa caixa = new Caixa();
                    caixa.Id = (long)rdr["id"];
                    caixa.Data = (DateTime)rdr["data"];
                    caixa.Saldo = (decimal)rdr["saldo"];
                    caixa.Status = rdr["status"].ToString();

                    caixas.Add(caixa);
                }

                return caixas;
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

        static public long GetNextId()
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "SELECT IDENT_CURRENT('Caixa') AS lastId";

                conexao.Open();
                long lastId = 0;
                long.TryParse(comando.ExecuteScalar().ToString(), out lastId);


                return lastId + 1;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }

        static public Library.Caixa GetCaixaToday()
        {
            if (Library.CaixaBD.FindAdvanced().Count > 0)
            {
                List<Library.Caixa> caixas = Library.CaixaBD.FindAdvanced(new QItem("c.data varchar", DateTime.Now.ToString("dd/MM/yyyy")));
                if (caixas.Count == 1)
                {
                    //certo
                    return caixas[0];
                }
                else if (caixas.Count < 1)
                {
                    //senão tiver caixa
                    Library.Caixa chj = new Library.Caixa();
                    chj.Data = DateTime.Today;
                    chj.Saldo = 0;
                    chj.Status = "Aberto";
                    Library.CaixaBD.Save(chj);

                    return chj;
                }
                else if (caixas.Count > 1)
                {
                    //se tiver mais de um caixa
                    throw new Exception("Existe mais de um caixa nesta data!");
                }
                //não precisa de verificar se tem menos de um pois já está verificado no "if (Library.CaixaBD.FindAdvanced().Length > 0)"
            }
            else
            {
                //senão tiver caixa
                Library.Caixa chj = new Library.Caixa();
                chj.Data = DateTime.Today;
                chj.Saldo = 0;
                chj.Status = "Aberto";
                Library.CaixaBD.Save(chj);

                return chj;
            }
            return null;
        }
        static public Library.Caixa GetCaixa(DateTime date)
        {
            if (Library.CaixaBD.FindAdvanced().Count > 0)
            {
                List<Library.Caixa> caixas = Library.CaixaBD.FindAdvanced(new QItem("c.data varchar", date.ToString("dd/MM/yyyy")));
                if (caixas.Count == 1)
                {
                    //certo
                    return caixas[0];
                }
                else if (caixas.Count < 1)
                {
                    //senão tiver caixa
                    Library.Caixa chj = new Library.Caixa();
                    chj.Data = date;
                    chj.Saldo = 0;
                    chj.Status = "Aberto";
                    Library.CaixaBD.Save(chj);

                    return chj;
                }
                else if (caixas.Count > 1)
                {
                    //se tiver mais de um caixa
                    throw new Exception("Existe mais de um caixa nesta data!");
                }
                //não precisa de verificar se tem menos de um pois já está verificado no "if (Library.CaixaBD.FindAdvanced().Length > 0)"
            }
            else
            {
                //senão tiver caixa
                Library.Caixa chj = new Library.Caixa();
                chj.Data = date;
                chj.Saldo = 0;
                chj.Status = "Aberto";
                Library.CaixaBD.Save(chj);

                return chj;
            }
            return null;
        }
    }
}
