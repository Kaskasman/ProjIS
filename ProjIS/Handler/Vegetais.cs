using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    public class Vegetais
    {
        private string nome;
        private int calorias;
        private string[] dose;

        public Vegetais(string nome, int calorias, string[] dose)
        {
            this.nome = nome;
            this.calorias = calorias;
            this.dose = dose;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        public string[] Dose
        {
            get { return dose; }
            set { dose = value; }
        }
    }
}
