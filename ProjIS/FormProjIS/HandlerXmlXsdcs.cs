using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Handler;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormProjIS
{
    public static class HandlerXmlXsdcs
    {
        private static List<Exercicio> exercicios = new List<Exercicio>();

        private static String line;
        private static string[] metAux;

        public static String criarXMLJson(String fileName)
        {
            string final = "";
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement exerciciosXml = doc.CreateElement("exercicios");
            doc.AppendChild(exerciciosXml);
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                exercicios = JsonConvert.DeserializeObject<List<Exercicio>>(json);
                for (int i = 0; i < exercicios.Count; i++)
                {
                    string linha = exercicios[i].ToString();
                    string[] nomes = linha.Split(' ');
                    XmlElement exercicioXml = doc.CreateElement("exercicio");
                    XmlElement nomeXml = doc.CreateElement("nome");
                    foreach (string s in nomes)
                    {
                        if (s != nomes[nomes.Length - 2] && s != nomes[nomes.Length - 1])
                        {
                            nomeXml.InnerText += s + " ";
                        }
                    }
                    nomeXml.InnerText.Trim();
                    XmlElement kcalXml = doc.CreateElement("kcal");
                    kcalXml.InnerText = nomes[nomes.Length - 2];

                    XmlElement metXml = doc.CreateElement("met");
                    metAux = nomes[nomes.Length - 1].Split(',');
                    if (metAux.Length > 1)
                    {
                        metXml.InnerText = metAux[0] + '.' + metAux[1];
                    }
                    else
                    {
                        metXml.InnerText = nomes[nomes.Length - 1];
                    }

                    exercicioXml.AppendChild(nomeXml);
                    exercicioXml.AppendChild(kcalXml);
                    exercicioXml.AppendChild(metXml);
                    exerciciosXml.AppendChild(exercicioXml);
                }
                doc.Save(@"exerciciosXml.xml");
                final = System.IO.Directory.GetCurrentDirectory().ToString() + "\\exerciciosXml.xml";
                FormProjIS.Properties.Settings.Default.XML = final;
                Properties.Settings.Default.Save();
            }
            return final;
        }

        public static String criarXMLTxt(String fileName)
        {
            String final = "";

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);

            XmlElement vegetais = doc.CreateElement("vegetais");
            doc.AppendChild(vegetais);

            StreamReader s = new StreamReader(fileName);

            while ((line = s.ReadLine()) != null)
            {
                string[] linha = line.Split('(', ')');
                string[] nomes = linha[0].Trim().Split(' ');
                string nome = "";
                string estado = "-";
                string calorias = "";
                string[] auxDose;
                string tipoDose = "";
                string dose = "";

                for (int i = 4; i < nomes.Length; i++)
                {
                    nome += nomes[i] + " ";
                }

                if (linha.Length > 3)
                {
                    estado = linha[linha.Length - 4];
                    calorias += nomes[1];

                    auxDose = linha[linha.Length - 2].Split(' ');
                    int count = 1;
                    foreach (string v in auxDose)
                    {
                        if (count == 1)
                        {
                            tipoDose = v;
                            count++;
                        }
                        else
                        {
                            dose += v;
                        }
                    }
                    
                    if (linha.Length >= 4)
                    {
                        nome += linha[1];
                    }
                }
                else if (linha.Length <= 3)
                {
                    auxDose = linha[linha.Length - 2].Split(' ');
                    int count = 1;
                    foreach (string v in auxDose)
                    {
                        if (count == 1)
                        {
                            tipoDose = v;
                            count++;
                        }
                        else
                        {
                            dose += v;
                        }
                    }
                    calorias += nomes[1];
                }

                XmlElement vegetal = doc.CreateElement("vegetal");

                XmlElement nomeXml = doc.CreateElement("nome");
                nomeXml.InnerText = nome.Trim();

                XmlElement kcalXml = doc.CreateElement("kcal");
                kcalXml.InnerText = calorias;

                XmlElement estadoXml = doc.CreateElement("estado");
                estadoXml.InnerText = estado;

                XmlElement tipoDeDoseXml = doc.CreateElement("tipoDose");
                tipoDeDoseXml.InnerText = dose;

                XmlElement doseXml = doc.CreateElement("dose");
                doseXml.InnerText = dose;

                vegetal.AppendChild(nomeXml);
                vegetal.AppendChild(kcalXml);
                vegetal.AppendChild(estadoXml);
                vegetal.AppendChild(tipoDeDoseXml);
                tipoDeDoseXml.AppendChild(doseXml);
                vegetais.AppendChild(vegetal);
            }
            doc.Save(@"vegetaisXml.xml");

            final = System.IO.Directory.GetCurrentDirectory().ToString() + "\\vegetaisXml.xml";
            FormProjIS.Properties.Settings.Default.XML = final;
            Properties.Settings.Default.Save();
            return final;
        }

        public static String criarXMLExcel(String fileName)
        {
            string final = "";

            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open(fileName);
            Excel.Worksheet excelWorkSheet = excelWorkBook.ActiveSheet;
            Excel.Range excelRange = excelWorkSheet.UsedRange;

            //int numberOfRows = excelRange.Rows.Count;
            //int numberOfCols = excelRange.Columns.Count;

            XmlDocument doc = new XmlDocument();

            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);

            XmlElement restaurantes = doc.CreateElement("restaurantes");
            doc.AppendChild(restaurantes);


            for (int row = 2; row < excelRange.Rows.Count; row++)
            {
                XmlElement restaurante = doc.CreateElement("restaurante");
                restaurante.SetAttribute("nomeRestaurante", excelWorkSheet.Cells[row, 1].Value);

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

                for (int aux = row + 1; aux < excelRange.Rows.Count; aux++)
                {
                    if (excelWorkSheet.Cells[aux, 1].Value == restaurante.GetAttribute("nomeRestaurante"))
                    {
                        XmlElement pratoAux = doc.CreateElement("prato");

                        XmlElement nomeXmlAux = doc.CreateElement("nome");
                        nomeXmlAux.InnerText = excelWorkSheet.Cells[aux, 2].Value;

                        XmlElement kcalXmlAux = doc.CreateElement("kcal");
                        kcalXmlAux.InnerText = excelWorkSheet.Cells[aux, 4].Value;

                        XmlElement quantidadeXmlAux = doc.CreateElement("quantidade");
                        quantidadeXmlAux.InnerText = excelWorkSheet.Cells[aux, 3].Value;

                        pratoAux.AppendChild(nomeXmlAux);
                        pratoAux.AppendChild(kcalXmlAux);
                        pratoAux.AppendChild(quantidadeXmlAux);
                        restaurante.AppendChild(pratoAux);

                        row++;
                    }
                }

                restaurantes.AppendChild(restaurante);

                doc.Save(@"restaurantesXml.xml");
                final = System.IO.Directory.GetCurrentDirectory().ToString() + "\\restaurantesXml.xml";
                FormProjIS.Properties.Settings.Default.XML = final;
                Properties.Settings.Default.Save();
                
            }
            return final;
        }


        public static void validarXML(string xml, string xsd)
        {
            string final;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsd);
            settings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create(xml, settings);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
        }
    }
}
