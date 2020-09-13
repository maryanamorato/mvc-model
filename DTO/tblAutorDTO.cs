using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO3B127.DTO
{
    public class tblAutorDTO
    {
        private int id_autor, idade_autor;
        private string nome_autor;

        public int idAutor { get => id_autor; set => id_autor = value; }

        public string nomeAutor
        {
            get { return nome_autor; }
            set
            {
                if (value != string.Empty)
                {
                    nome_autor = value;
                }
                else
                {
                    throw new Exception("Nome é obrigatório.");
                }
            }
        }

        public int idadeAutor { 
            get { return idade_autor; }
            set
            {
                if(value >= 0)
                {
                    idade_autor = value;
                }
                else
                {
                    throw new Exception("Idade inválida.");
                }
            }
        }
    }
}