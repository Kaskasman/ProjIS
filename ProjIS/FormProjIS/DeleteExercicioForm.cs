using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormProjIS
{
    public partial class DeleteExercicioForm : Form
    {
        private Service1 client;
        private string token;

        public DeleteExercicioForm(Service1 client, string token)
        {
            InitializeComponent();
            this.client = client;
            this.token = token;

            ListViewItem lvi = new ListViewItem();
            Exercicio[] exercicios = client.GetListaExercicios(token);
            foreach (Exercicio exer in exercicios)
            {
                lvi.SubItems.Add(exer.Nome);
                lvi.SubItems.Add(exer.Calorias.ToString());
                lvi.SubItems.Add(exer.Met.ToString());

                listViewExercicios.Items.Add(lvi);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewExercicios_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que pretende Eleminar Vegetal", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                client.DeleteVegetal(listViewExercicios.SelectedItems[0].SubItems[0].Text, token);

                MessageBox.Show("Exercicio Eleminado com Sucesso.");
            }           
        }
    }
}
