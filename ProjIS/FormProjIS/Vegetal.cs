using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProjIS
{
    public class Vegetal
    {
        private string nome;
        private string calorias;
        private string dose;
        private string estado;

        public Vegetal(string nome, string estado, string calorias, string dose)
        {
            this.nome = nome;
            this.estado = estado;
            this.calorias = calorias;
            this.dose = dose;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        public string Dose
        {
            get { return dose; }
            set { dose = value; }
        }

        public override string ToString()
        {
            return nome + "|" + estado + "|" + calorias + " kcal|" + dose;
        }
    }
}
