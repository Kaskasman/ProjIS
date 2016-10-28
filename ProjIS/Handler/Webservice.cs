using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Handler
{
    public class Webservice
    {
        private string line;
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("calorias_exercicio.js"))
            {
                string json = r.ReadToEnd();
                List<Exercicios> execicios = JsonConvert.DeserializeObject<List<Exercicios>>(json);
            }

            StreamReader s = new StreamReader("calorias_Vegetais.txt");
            List<Vegetais> vegetais = new List<Vegetais>();

            while ((line = s.ReadLine()) != null)
            {
                string[] linha = line.Split('(');
                string[] nomes = linha[0].Split(' ');

                //Vegetais veg = new Vegetais(linha[4], linha[1], {});
            }
        }


        
    }
}
