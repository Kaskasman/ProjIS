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
        String xml;
        String xsd;

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
                        metXml.InnerText = nomes[nomes.Length - 1];
                        exercicioXml.AppendChild(nomeXml);
                        exercicioXml.AppendChild(kcalXml);
                        exercicioXml.AppendChild(metXml);
                        exerciciosXml.AppendChild(exercicioXml);
                    }
                    doc.Save(@"exerciciosXml.xml");
                    tb_filePath.Text = System.IO.Directory.GetCurrentDirectory().ToString() + "\\exerciciosXml.xml";
                    FormProjIS.Properties.Settings.Default.XML = tb_filePath.Text;
                    MessageBox.Show("XML criado com sucesso", "Sucesso", MessageBoxButtons.OK);
                }
            }
        }

        private void bt_carregarTXT_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT Files|*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath;

            String final = "";

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);

            XmlElement vegetais = doc.CreateElement("vegetais");
            doc.AppendChild(vegetais);

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader s = new StreamReader(openFileDialog1.FileName);
                

                while ((line = s.ReadLine()) != null)
                {
                    string[] linha = line.Split('(', ')');
                    string[] nomes = linha[0].Trim().Split(' ');
                    string nome = "";
                    string estado = "-";
                    string calorias = "";
                    string dose = "";

                    for (int i = 4; i < nomes.Length; i++)
                    {
                        nome += nomes[i] + " ";
                    }

                    if (linha.Length > 3)
                    {
                        estado = linha[linha.Length - 4];
                        dose += linha[linha.Length - 2];
                        calorias += nomes[1];
                        if (linha.Length >= 4)
                        {
                            nome += linha[1];
                        }
                    }
                    else if (linha.Length <= 3)
                    {
                        dose += linha[linha.Length - 2];
                        calorias += nomes[1];
                    }

                    XmlElement vegetal = doc.CreateElement("vegetal");

                    XmlElement nomeXml = doc.CreateElement("nome");
                    nomeXml.InnerText = nome.Trim();

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

                    //para tirar futuro
                    Vegetal veg = new Vegetal(nome, estado, calorias, dose);
                    final += veg.ToString() + "\n";
                }
                doc.Save(@"vegetaisXml.xml");
                rtb_display.Text = final;
                tb_filePath.Text = System.IO.Directory.GetCurrentDirectory().ToString() + "\\vegetaisXml.xml";
                FormProjIS.Properties.Settings.Default.XML = tb_filePath.Text;

                MessageBox.Show("XML criado com sucesso", "Sucesso", MessageBoxButtons.OK);
            }
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
                    tb_filePath.Text = System.IO.Directory.GetCurrentDirectory().ToString() + "\\restaurantesXml.xml";
                    FormProjIS.Properties.Settings.Default.XML = tb_filePath.Text;

                    //para tirar futuro
                    Restaurante rest = new Restaurante(excelWorkSheet.Cells[row, 1].Value,
                    excelWorkSheet.Cells[row, 2].Value, excelWorkSheet.Cells[row, 3].Value,
                    excelWorkSheet.Cells[row, 4].Value);
                    final += rest.ToString() + "\n";
                }
                rtb_display.Clear();
                rtb_display.Text = final;

                MessageBox.Show("XML criado com sucesso", "Sucesso", MessageBoxButtons.OK);
            }
        }

        private void bt_validar_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xsd);
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(xml, settings);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
            }
            catch (Exception ex)
            {
                isValid = false;
                string[] aux = ex.Message.Split('-');
                foreach (String i in aux)
                {
                    MessageBox.Show(i);
                }

                //MessageBox.Show(ex.Message, "titulo", MessageBoxButtons.OK);
            }
            finally
            {
                MessageBox.Show(isValid ? "O doc é valido" : "O doc é invalido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            op1.FilterIndex = 1;

            if (op1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = op1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            tb_filePath.Text = op1.FileName;
                            xml = op1.FileName;
                            FormProjIS.Properties.Settings.Default.XML = op1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "XSD files (*.xsd)|*.xsd|All files (*.*)|*.*";
            op1.FilterIndex = 1;

            if (op1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = op1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            tb_xsd.Text = op1.FileName;
                            xsd = op1.FileName;
                            FormProjIS.Properties.Settings.Default.XSD = op1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}