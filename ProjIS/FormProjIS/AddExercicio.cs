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
    public partial class AddExercicio : Form
    {
        private Service1 client;
        private string token;

        public AddExercicio(Service1 client, string token)
        {
            InitializeComponent();
            this.client = client;
            this.token = token;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Exercicio exer = new Exercicio(textBoxNome.Text, int.Parse(textBoxKCal.Text), float.Parse(textBoxMet.Text));

                client.AddExercicio(exer, token);

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
