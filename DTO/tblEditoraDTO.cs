using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3B127.DTO
{
    public class tblEditoraDTO
    {
        private int id_editora;
        private string nome_editora, endereco_editora, uf_editora;

        public int idEditora { get => id_editora; set => id_editora = value; }

        public string nomeEditora
        {
            get { return nome_editora; }
            set
            {
                if (value != string.Empty)
                {
                    nome_editora = value;
                }
                else
                {
                    throw new Exception("E-mail é obrigatório.");
                }
            }
        }

        public string enderecoEditora
        {
            get { return endereco_editora; }
            set
            {
                if (value != string.Empty)
                {
                    endereco_editora = value;
                }
                else
                {
                    throw new Exception("Endereço é obrigatório.");
                }
            }
        }

        public string ufEditora
        {
            get { return uf_editora; }
            set
            {
                if (value != string.Empty)
                {
                    uf_editora = value;
                }
                else
                {
                    throw new Exception("UF é obrigatório.");
                }
            }
        }
    }
}