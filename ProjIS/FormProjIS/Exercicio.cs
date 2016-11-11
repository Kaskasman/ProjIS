using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProjIS
{
    public class Exercicio
    {
        private string nome;
        private int calorias;
        private float met;

        public Exercicio(string nome, int calorias, float met)
        {
            this.Nome = nome;
            this.Calorias = calorias;
            this.Met = met;
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public int Calorias
        {
            get
            {
                return calorias;
            }

            set
            {
                calorias = value;
            }
        }

        public float Met
        {
            get
            {
                return met;
            }

            set
            {
                met = value;
            }
        }

        public override string ToString()
        {
            return nome + " " + calorias + " " + met;
        }
    }
}
