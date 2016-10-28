using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    public class Vegetal
    {
        private string nome;
        private int calorias;
        private string dose;

        public Vegetal(string nome, int calorias, string dose)
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
