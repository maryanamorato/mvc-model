using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using POO3B127.DAL;
using POO3B127.DTO;

namespace POO3B127.BLL
{
    public class tblAutorBLL
    {
        private DALMysql daoBanco = new DALMysql();
        public DataTable listarAutores()
        {
            string sql = string.Format($@"SELECT * FROM tbl_autor");
            return daoBanco.executarConsulta(sql);
        }

        public void criarAutor(tblAutorDTO dados)
        {
            string sql = string.Format($@"INSERT INTO tbl_autor VALUES (NULL, '{dados.nomeAutor}', '{dados.idadeAutor}');");
            daoBanco.executarComando(sql);
        }

        public void deletarAutor(tblAutorDTO dados)
        {
            string sql = string.Format($@"DELETE FROM tbl_autor where id = {dados.idAutor};");
            daoBanco.executarComando(sql);
        }

        public void atualizarAutor(tblAutorDTO dados)
        {
            string sql = string.Format($@"UPDATE tbl_autor SET nome = '{dados.nomeAutor}', idade = '{dados.idadeAutor}' ) WHERE id = {dados.idAutor};");
            daoBanco.executarComando(sql);
        }
    }
}