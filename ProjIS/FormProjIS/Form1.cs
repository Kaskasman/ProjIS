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
                List<Vegetal> vegetais = new List<Vegetal>();
                
                while ((line = s.ReadLine()) != null)
                {
                    string[] linha = line.Split('(');
                    string[] nomes = linha[0].Split(' ');
                    char mc = ')';
                    string nome = "";
                    for (int i = 4; i < nomes.Length; i++)
                    {
                        nome += nomes[i];
                    }

                    if (linha.Length > 2)
                    {
                        nome += linha[1];
                    }

                    Vegetal veg = new Vegetal(nome, Convert.ToInt16(nomes[1]), linha[linha.Length - 1].TrimEnd(mc));
                    final += veg.ToString() + "\n";
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