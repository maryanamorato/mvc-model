using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace POO3B127.DAL
{
    public class DALMysql
    {
        private string string_conexao = "Persist Security info=false ; server=localhost ; database=bd_Livraria ; user=root ; pwd=''";
        private MySqlConnection conexao;

        public void Conectar()
        {
            try
            {
                conexao = new MySqlConnection(string_conexao);
                conexao.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception("Problema ao conectar ao banco de dados: " + e.Message);
            }
        }

        public void executarComando(string sql)
        {
            try
            {
                Conectar();
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.ExecuteNonQuery();
            }
            catch(MySqlException e)
            {
                throw new Exception("Não foi possível executar a instrução: " + e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable executarConsulta(string sql)
        {
            try
            {
                Conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dados = new MySqlDataAdapter(sql, conexao);
                dados.Fill(dt);
                return dt;
            }
            catch (MySqlException e)
            {
                throw new Exception("Não foi possível executar a consulta: " + e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}