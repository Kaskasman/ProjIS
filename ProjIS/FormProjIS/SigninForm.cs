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
    public partial class SigninForm : Form
    {
        private Service1 client;
        private string token;

        public SigninForm(Service1 client, string token)
        {
            InitializeComponent();
            this.client = client;
            this.token = token;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.Username = textBoxUsername.Text;
                user.Password = textBoxPassword.Text;
                user.Admin = radioButtonAdminYes.Checked;
                client.SignUp(user, token);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            this.Close();
        }
    }
}
