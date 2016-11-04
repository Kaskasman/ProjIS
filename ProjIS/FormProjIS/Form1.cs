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
        private static String xml;
        private static String xsd;

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
                try
                {
                    String filePath = HandlerXmlXsdcs.criarXMLJson(openFileDialog1.FileName);
                    tb_filePath.Text = filePath;
                    MessageBox.Show("XML criado com sucesso", "Sucesso", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
                    throw;
                }
                
            }
        }

        private void bt_carregarTXT_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT Files|*.txt";
            openFileDialog1.InitialDirectory = Application.StartupPath;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    String filePath = HandlerXmlXsdcs.criarXMLTxt(openFileDialog1.FileName);
                    tb_filePath.Text = filePath;
                    MessageBox.Show("XML criado com sucesso", "Sucesso", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
                    throw;
                }
            }
        }

        private void bt_carregarEXCEL_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "EXCEL Files|*.xls";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    String filePath = HandlerXmlXsdcs.criarXMLExcel(openFileDialog1.FileName);
                    tb_filePath.Text = filePath;
                    MessageBox.Show("XML criado com sucesso", "Sucesso", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK);
                    throw;
                }
            }
        }

        private void bt_validar_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            try
            {
                HandlerXmlXsdcs.validarXML(xml, xsd);
                MessageBox.Show("XML validado com sucesso", "Sucesso", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                isValid = false;
                string[] aux = ex.Message.Split('-');
                foreach (String i in aux)
                {
                    MessageBox.Show(i);
                }
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
                            Properties.Settings.Default.Save();
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
                            Properties.Settings.Default.Save();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_filePath.Text = FormProjIS.Properties.Settings.Default.XML;
            tb_xsd.Text = FormProjIS.Properties.Settings.Default.XSD;

            xml = tb_filePath.Text = FormProjIS.Properties.Settings.Default.XML;
            xsd = tb_xsd.Text = FormProjIS.Properties.Settings.Default.XSD;
        }
    }
}