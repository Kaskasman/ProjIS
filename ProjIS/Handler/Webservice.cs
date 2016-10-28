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

        //public void LoadJson()
        //{
        //    using (StreamReader r = new StreamReader("calorias_exercicio.js"))
        //    {
        //        string json = r.ReadToEnd();
        //        List<Exercicio> execicios = JsonConvert.DeserializeObject<List<Exercicio>>(json);
        //    }
        //}

        //public void LoadTxt()
        //{

        //    StreamReader s = new StreamReader("calorias_Vegetais.txt");
        //    List<Vegetal> vegetais = new List<Vegetal>();

        //    while ((line = s.ReadLine()) != null)
        //    {
        //        string[] linha = line.Split('(');
        //        string[] nomes = linha[0].Split(' ');

        //        string nome = "";
        //        for (int i = 4; i < nomes.Length; i++)
        //        {
        //            nome += nomes[i];
        //        }

        //        if (linha.Length > 2)
        //        {
        //            nome += linha[1];
        //        }
        //        String dosagem = linha[linha.Length - 1].Trim(')');

        //        Vegetal veg = new Vegetal(nome, Convert.ToInt16(nomes[1]), dosagem);
        //    }
        //}

        //public void LoadExcel()
        //{
        //    Excel.Application excelApplication = new Excel.Application();
        //    excelApplication.Visible = false;
        //    Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open("calorias_restaurantes.xls");
        //    Excel.Worksheet excelWorkSheet = excelWorkBook.ActiveSheet;

        //    List<Restaurante> restaurantes = new List<Restaurante>();

        //    for (int i = 1; i <= excelWorkSheet.Rows.Count; i++)
        //    {
        //        //lista restaurantes
        //    }
        //}
    }
}
