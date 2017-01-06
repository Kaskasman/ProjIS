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
    public partial class AddPratoForm : Form
    {
        private Service1 client;
        private string token;

        public AddPratoForm(Service1 client, string token)
        {
            InitializeComponent();
            this.client = client;
            this.token = token;

            Restaurante[] restaurantesNome = client.GetAllRestaurantes(token);
            foreach (Restaurante r in restaurantesNome)
            {
                comboBoxRestaurante.Items.Add(r);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Restaurante r = new Restaurante(comboBoxRestaurante.SelectedText, textBoxNome.Text, textBoxKCal.Text, textBoxQuantidade.Text);

                client.AddExercicio(r, token);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
