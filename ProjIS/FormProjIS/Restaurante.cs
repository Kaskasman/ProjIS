using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    public class Restaurante
    {
        private string nomeRestaurante;
        private string nome;
        private string quantidade;
        private string calorias;

        public Restaurante(string nomeRestaurante, string nome, string quantidade, string calorias)
        {
            this.nomeRestaurante = nomeRestaurante;
            this.nome = nome;
            this.quantidade = quantidade;
            this.calorias = calorias;
        }

        public string NomeRestaurante
        {
            get { return nomeRestaurante; }
            set { nomeRestaurante = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        public override string ToString()
        {
            return nomeRestaurante + " " + nome + " " + quantidade + " " + calorias;
        }
    }
}
