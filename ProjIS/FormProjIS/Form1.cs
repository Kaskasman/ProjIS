using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handler;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormProjIS
{
    public partial class Form1 : Form
    {
        private List<Exercicio> exercicios = new List<Exercicio>();
        private List<Vegetal> vegetais = new List<Vegetal>();
        private List<Restaurante> restaurantes = new List<Restaurante>();
        private String line;

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_carregarJS_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Json Files|*.js";
            openFileDialog1.InitialDirectory = Application.StartupPath;
           
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader r = new StreamReader(openFileDialog1.FileName))
                {
                    string json = r.ReadToEnd();
                    exercicios = JsonConvert.DeserializeObject<List<Exercicio>>(json);
                }
            }
        }

        private void bt_carregarTXT_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT Files|*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath;

            String final = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader s = new StreamReader(openFileDialog1.FileName);
                
                while ((line = s.ReadLine()) != null)
                {
                    string[] linha = line.Split('(', ')');
                    string[] nomes = linha[0].Split(' ');
                    string nome = "";
                    string estado = "";
                    string calorias = "";
                    string dose = "";

                    for (int i = 4; i < nomes.Length; i++)
                    {
                        nome += nomes[i];
                    }

                    if (linha.Length > 3)
                    {
                        estado += linha[1];
                        dose += linha[3];
                        calorias += nomes[1];
                    }
                    else if(linha.Length <= 3)
                    {
                        dose += linha[1];
                        calorias += nomes[1];
                    }

                    Vegetal veg = new Vegetal(nome, estado, calorias, dose);
                    final += veg.ToString() + "\n";
                }
            }
            rtb_display.Text = final;
        }

        private void bt_carregarEXCEL_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "EXCEL Files|*.xls";
            openFileDialog1.InitialDirectory = Application.StartupPath;

            string final = "";
            string nomeR = "";
            string nome = "";
            string quantidade = "";
            string calorias = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Excel.Application excelApplication = new Excel.Application();
                excelApplication.Visible = false;
                Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open(openFileDialog1.FileName);
                Excel.Worksheet excelWorkSheet = excelWorkBook.ActiveSheet;
                Excel.Range excelRange = excelWorkSheet.UsedRange;

                //int numberOfRows = excelRange.Rows.Count;
                //int numberOfCols = excelRange.Columns.Count;

                for (int row = 2; row < excelRange.Rows.Count; row++)
                {
                    //nomeR = excelWorkSheet.Cells[row, 1].Value;
                    //nome = excelWorkSheet.Cells[row, 2].Value;
                    //quantidade = excelWorkSheet.Cells[row, 3].Value;
                    //calorias = excelWorkSheet.Cells[row, 4].Value;

                    Restaurante rest = new Restaurante(excelWorkSheet.Cells[row, 1].Value, excelWorkSheet.Cells[row, 2].Value, excelWorkSheet.Cells[row, 3].Value, excelWorkSheet.Cells[row, 4].Value);
                    final += rest.ToString() + "\n";                   
                }              
            }
            rtb_display.Text = final;
        }
    }
}

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