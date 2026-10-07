using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace cadastroDeAlunos
{
    public class AlunoDB
    {
        string conexaoString;
        MySqlConnection CN;

        public AlunoDB()
        {
            conexaoString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
        }

        public void IncluirAluno(Aluno alunos)
        {
            CN = new MySqlConnection(conexaoString);
            MySqlCommand Com = CN.CreateCommand();

            Com.CommandText = "INSERT INTO alunos (matricula, nome, n1, n2, Media, Status) VALUES (?matricula, ?nome, ?n1, ?n2, ?media, ?status)";

            Com.Parameters.AddWithValue("?matricula", alunos.getMatricula());
            Com.Parameters.AddWithValue("?nome", alunos.getNome());
            Com.Parameters.AddWithValue("?n1", alunos.getN1());
            Com.Parameters.AddWithValue("?n2", alunos.getN2());
            Com.Parameters.AddWithValue("?media", alunos.getMedia());
            Com.Parameters.AddWithValue("?status", alunos.getStatus());

            try
            {
                CN.Open();
                int registrosAfetados = Com.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                CN.Close();
            }
        }

        public DataTable getAlunos()
        {
            CN = new MySqlConnection(conexaoString);
            MySqlCommand cmd = CN.CreateCommand();
            MySqlDataAdapter da;

            cmd.CommandText = "SELECT * FROM alunos";

            try
            {
                CN.Open();
                cmd = new MySqlCommand(cmd.CommandText, CN);
                da = new MySqlDataAdapter(cmd);
                DataTable dtAlunos = new DataTable();
                da.Fill(dtAlunos);
                return dtAlunos;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                CN.Close();
            }
        }
    }
}