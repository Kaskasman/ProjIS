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
    public partial class DeleteVegetalForm : Form
    {
        private Service1 client;
        private string token;

        public DeleteVegetalForm(Service1 client, string token)
        {
            InitializeComponent();
            this.client = client;
            this.token = token;

            ListViewItem lvi = new ListViewItem();
            Vegetal[] vegetais = client.GetListaVegetais(token);
            foreach (Vegetal v in vegetais)
            {            
                lvi.SubItems.Add(v.Nome);
                lvi.SubItems.Add(v.Calorias);
                lvi.SubItems.Add(v.TipoDeDose);
                lvi.SubItems.Add(v.Estado);
                lvi.SubItems.Add(v.Dose);

                listViewVegetais.Items.Add(lvi);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewVegetais_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que pretende Eleminar Vegetal", "Aviso", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                client.DeleteVegetal(listViewVegetais.SelectedItems[0].SubItems[0].Text, token);

                MessageBox.Show("Vegetal Eleminado com Sucesso.");
            }
        }
    }
}
