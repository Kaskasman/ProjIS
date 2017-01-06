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
    public partial class DeletePratoForm : Form
    {
        private Service1 client;
        private string token;

        public DeletePratoForm(Service1 client, string token)
        {
            InitializeComponent();
            this.client = client;
            this.token = token;

            ListViewItem lvi = new ListViewItem();
            Restaurante[] restaurantes = client.GetListaPratos(token);
            foreach (Restaurante r in restaurantes)
            {
                lvi.SubItems.Add(r.NomeRestaurante);
                lvi.SubItems.Add(r.Nome);
                lvi.SubItems.Add(r.Calorias);
                lvi.SubItems.Add(r.Quantidade);

                listViewPratos.Items.Add(lvi);
            }
        }

        private void listViewPratos_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que pretende Eleminar Vegetal", "Aviso", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                client.DeleteVegetal(listViewPratos.SelectedItems[0].SubItems[1].Text, token);

                MessageBox.Show("Prato Eleminado com Sucesso.");
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
