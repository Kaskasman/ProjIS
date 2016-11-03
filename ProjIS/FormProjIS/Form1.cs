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
using System.Xml;
using Newtonsoft.Json.Linq;

namespace FormProjIS
{
    public partial class Form1 : Form
    {
        private List<Exercicio> exercicios = new List<Exercicio>();
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
                XmlDocument doc = new XmlDocument();

                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);

                XmlElement exerciciosXml = doc.CreateElement("exercicios");
                doc.AppendChild(exerciciosXml);

                using (StreamReader r = new StreamReader(openFileDialog1.FileName))
                {
                    string json = r.ReadToEnd();

                    //fazer splits por { e :

                    XmlElement exercicioXml = doc.CreateElement("exercicio");

                    XmlElement nomeXml = doc.CreateElement("nome");
                    nomeXml.InnerText = JObject.Parse(json)["Nome"].ToString();

                    XmlElement kcalXml = doc.CreateElement("kcal");
                    kcalXml.InnerText = JObject.Parse(json)["Calorias"].ToString();

                    XmlElement metXml = doc.CreateElement("met");
                    metXml.InnerText = JObject.Parse(json)["Met"].ToString();

                    exercicioXml.AppendChild(nomeXml);
                    exercicioXml.AppendChild(kcalXml);
                    exercicioXml.AppendChild(metXml);
                    exerciciosXml.AppendChild(exercicioXml);

                    doc.Save(@"exerciciosXml.xml");

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

                    XmlDocument doc = new XmlDocument();

                    XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                    doc.AppendChild(dec);

                    XmlElement vegetais = doc.CreateElement("vegetais");
                    doc.AppendChild(vegetais);

                    XmlElement vegetal = doc.CreateElement("vegetal");

                    XmlElement nomeXml = doc.CreateElement("nome");
                    nomeXml.InnerText = nome;

                    XmlElement kcalXml = doc.CreateElement("kcal");
                    kcalXml.InnerText = calorias;

                    XmlElement estadoXml = doc.CreateElement("estado");
                    estadoXml.InnerText = estado;

                    XmlElement doseXml = doc.CreateElement("dose");
                    doseXml.InnerText = dose;

                    vegetal.AppendChild(nomeXml);
                    vegetal.AppendChild(kcalXml);
                    vegetal.AppendChild(estadoXml);
                    vegetal.AppendChild(doseXml);
                    vegetais.AppendChild(vegetal);

                    doc.Save(@"vegetaisXml.xml");
                    

                    //para tirar futuro
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

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Excel.Application excelApplication = new Excel.Application();
                excelApplication.Visible = false;
                Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open(openFileDialog1.FileName);
                Excel.Worksheet excelWorkSheet = excelWorkBook.ActiveSheet;
                Excel.Range excelRange = excelWorkSheet.UsedRange;

                //int numberOfRows = excelRange.Rows.Count;
                //int numberOfCols = excelRange.Columns.Count;

                XmlDocument doc = new XmlDocument();

                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);

                XmlElement restaurantes = doc.CreateElement("restaurantes");
                doc.AppendChild(restaurantes);

                for (int row = 2; row < excelRange.Rows.Count; row++)
                {
                    XmlElement restaurante = doc.CreateElement("restaurante");
                    restaurante.SetAttribute("nomeRestaurante", excelWorkSheet.Cells[row, 1].Value); //Convert.ToString(nomeR)

                    // ver se o restaurante ja foi inserido se sim continuar a inserir se nao inserir novo restaurante e pratos
                    if (excelWorkSheet.Cells[row, 1].Value == restaurante)
                    {
                        
                    }

                    // criar FOR para cada restaurante
                    //for (int rowLinha = 2; rowLinha < excelRange.Rows.Count; rowLinha++)
                    //{
                        XmlElement prato = doc.CreateElement("prato");

                        XmlElement nomeXml = doc.CreateElement("nome");
                        nomeXml.InnerText = excelWorkSheet.Cells[row, 2].Value;

                        XmlElement kcalXml = doc.CreateElement("kcal");
                        kcalXml.InnerText = excelWorkSheet.Cells[row, 4].Value;

                        XmlElement quantidadeXml = doc.CreateElement("quantidade");
                        quantidadeXml.InnerText = excelWorkSheet.Cells[row, 3].Value;

                        prato.AppendChild(nomeXml);
                        prato.AppendChild(kcalXml);
                        prato.AppendChild(quantidadeXml);
                        restaurante.AppendChild(prato);
                        restaurantes.AppendChild(restaurante);

                    //doc.Save(@"restauranteXml.xml");
                    //}

                    doc.Save(@"restaurantesXml.xml");

                    //para tirar futuro
                    Restaurante rest = new Restaurante(excelWorkSheet.Cells[row, 1].Value, excelWorkSheet.Cells[row, 2].Value, excelWorkSheet.Cells[row, 3].Value, excelWorkSheet.Cells[row, 4].Value);
                    final += rest.ToString() + "\n";
                }              
            }

            rtb_display.Clear();
            rtb_display.Text = final;
        }
    }
}